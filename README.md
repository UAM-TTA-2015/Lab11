# Tworzenie testowalnych aplikacji
## Laboratorium #11 - Testy aplikacyjne cz. 2

### Prowadzący zajęcia
Bartosz Sokół, Nikodem Rafalski

### Opis zajęć
Na dziesiątych zajęciach pokażemy jak tworzyć rozbudowane testy obejmujące całą aplikację.
Zobaczymy jak opisywać złożone wymagania w przyjazny sposób oraz jak je tłumaczyć na kod testów.
Dowiemy się jak zautomatyzować operacje na interfejsie aplikacji webowej.

### Materiały
* Wymagania które ma spełniać nasza aplikacja: [Wymagania](Wymagania.md)
* Zadanie domowe i informacje o projektach: [Zadanie domowe i projekt](ZadanieDomowe.md)
* Kod: [UamTTA](kod/UamTTA)
* Uruchamianie aplikacji webowej: [Instrukcja](Uruchamianie.md)

### Pomocne zasoby

Narzędzia użyte przy tworzeniu przykdowej aplikacji webowej
* [Angular.js](https://angularjs.org/)
* [Tutorial Angular](http://www.w3schools.com/angular/)
* [node.js](https://nodejs.org/en/) - użyte do serwowania aplikacji

Testy aplikacji webowej będziemy uruchamiać za pomocą Selenium:
* [Strona Selenium](http://docs.seleniumhq.org/)
* [Pakiety NuGet Selenium dla projektów .NET](https://www.nuget.org/profiles/selenium)

Behavior Driven Development - materiały:
* [Opis BDD](https://en.wikipedia.org/wiki/Behavior-driven_development)
* [Wprowadzenie do BDD](http://dannorth.net/introducing-bdd/)
* [Cucumber / Gherkin - metajęzyk opisu wymagań](https://cucumber.io/)
* [SpecFlow - implementacja Cucumber dla .NET](http://www.specflow.org/)

Do kontaktu z bazą danych będziemy używać Entity Framework w wersji 6.x. Materiały o EF:
* [Wprowadzenie do EF6 Code First](https://msdn.microsoft.com/en-us/data/jj193542.aspx?f=255&MSPPError=-2147217396)
* [Materiały video na Channel9](https://channel9.msdn.com/Search?term=entity%20framework#ch9Search&lang-en=en)
* [Strona główna EF6](http://entityframework.codeplex.com/)

Nasze API będzie wystawione poprzez ASP.NET MVC 5 / WebAPI 2 i będzie zgodne z protokołem REST. Materiały:
* [Protokół REST](https://en.wikipedia.org/wiki/Representational_state_transfer)
* [Narzędzie do testowania wywołań REST z Chrome - Postman](https://chrome.google.com/webstore/detail/postman/fhbjgbiflinjbdggehcddcbncdddomop)
* [Tutorial ASP.NET Web API 2](http://www.asp.net/web-api/overview/getting-started-with-aspnet-web-api/tutorial-your-first-web-api)

Kod powstały na zajęciach będzie budowany przez build server TeamCity:
* [Informacje o TeamCity](https://www.jetbrains.com/teamcity/)
* [Nasz serwer TeamCity](http://tta2015z.vm.wmi.amu.edu.pl:8111/)
