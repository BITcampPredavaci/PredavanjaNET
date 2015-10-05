(function() {
  // Kreiramo našu aplikaciju
  var repos = angular.module('repos', []);

  // Konfigurišemo $httpProvider kako bi svi $http servisi koristili istu
  // autorizaciju. Ako želimo preciznije konfigurisati autorizaciju na
  // različite servise (npr. u zavisnosti od URL-a) onda možemo koristi
  // inteceptor:
  // https://docs.angularjs.org/api/ng/service/$http#interceptors
  repos.config(['$httpProvider', function($httpProvider) {
    $httpProvider.defaults.headers.common.Authorization = 'Basic ' +
        btoa('<username>:<token>');
  }]);

  // Konstruišemo repositoriesSource service objekat koji ćemo koristiti za
  // dohvaćanje podataka i za paging.
  repos.service('repositoriesSource', ['$http', function($http) {
    var service = {};

    service.page = 1;
    service.pages = [1, 2, 3, 4, 5];
    service.repositories = [];

    // Učitava repozitorije sa GitHub-a za specificirani username u servis.
    // Pazi na to da se referenca na `repositories` niz ne mijenja, već mutira
    // niz brišući elemente iz njega (koristeći `pop()`), i dodajući nove
    // koristeći (koristeći `push()`).
    service.load = function() {
      return $http.get("https://api.github.com/users/" +
             service.username + "/repos?page=" + service.page)
        .then(function(result) {
          while(service.repositories.length > 0) {
            service.repositories.pop();
          }

          for (var i = 0; i < result.data.length; i++) {
            service.repositories.push(result.data[i]);
          }
        });
    };

    // Dohvaća naziv posljednjeg issue-a kroz promise. Obratite pažnju da
    // vraćamo promise, tj. obekat koji dobijemo kada pozovemo `$http.get()` te
    // pozivatelj ove metode može nakon nje dodati `then()`
    service.getIssues = function(repo) {
      var issuesUrl = repo.issues_url.replace('{/number}', '');
      return $http.get(issuesUrl);
    };

    service.next = function() {
      service.page += 1;
      service.load();
    };

    service.previous = function() {
      service.page -= 1;
      service.load();
    };

    service.goto = function(page) {
      service.page = page;
      service.load();
    };

    service.hasPrevious = function() {
      return service.page > 1;
    };

    return service;
  }]);

  // Kontroler koji koristi repositoriesSource za dobavljanje informacija o
  // repozitorijima. Ovaj service ostavljamo dostupan kroz `pager` atribut kako
  // bismo mogli vezati paging akcije (`next`, `previous`, `goto` i
  // `hasPrevious`) za dugmad u view-u.
  repos.controller('RepositoryListController', ['repositoriesSource', function(repositoriesSource) {
    var vm = this;

    // Obratite pažnju da je `vm.repositories` referenca na `repositories`
    // atribut našeg servisa. Ako taj servis ikad zamijeni ovaj niz nekim
    // drugim podaci u view-u se neće ispravno osvježavati.
    vm.repositories = repositoriesSource.repositories;
    vm.username = 'aspnet';
    vm.pager = repositoriesSource;

    // Poziv na reload() dobavlja repozitorije za trenutno unijeti username.
    vm.reload = function() {
      repositoriesSource.username = vm.username;
      repositoriesSource.goto(1);
    };

    vm.reload();
  }]);

  // Kontroler koji se tiče jednog repozitorija. Jedina stvar koju implementira
  // je dobavljanje informacija o issue-ima otvorenim za kliknuti repozitorij.
  repos.controller('RepositoryController', ['repositoriesSource', function(repositoriesSource) {
    var vm = this;

    vm.details = '';

    vm.showDetails = function(repo) {
      repositoriesSource.getIssues(repo)
        .then(function(result) {
          var lastIssue = result.data[0];
          var lines = [];
          lines.push("Full repository name: " + repo.full_name);
          lines.push("Open issues count: " + repo.open_issues_count);

          if (result.data.length > 0) {
            lines.push("Last opened issue's title: " + result.data[0].title);
          }

          vm.details = lines.join('\n\n');
        });
    };
  }]);

})();
