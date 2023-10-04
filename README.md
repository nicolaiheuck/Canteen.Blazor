![Build succeeded][build-shield]
![Test passing][test-shield]
[![Issues][issues-shield]][issues-url]
[![Issues][closed-shield]][issues-url]
[![Contributors][contributors-shield]][contributors-url]
[![Forks][forks-shield]][forks-url]
[![License][license-shield]][license-url]

# DOOM
#### Daily Offered Organic Menu
<!-- TABLE OF CONTENTS -->
<details>
  <summary>Table of Contents</summary>

- [Case](#case)
- [Requirements](#requirements)
- [Architecture diagram](#architecture-diagram)
- [Roadmap](#roadmap)
- [Summary and rundown](#summary-and-rundown)
- [Getting started](#getting-started)
- [Libraries](#libraries)
- [Database Diagram](#database-diagram)
- [Flowcharts](#flowcharts)
- [License](#license)
- [Contact](#contact)
</details>

# Case
Inspireret af udenlandske eksempler ønsker IT-Center Syd at udvikle og implementere en række nye IT-services:
> Info ved retterne i skolernes kantinen buffet: Implementer displays ved buffeten, der viser information om de tilberedte retter, 
> herunder ingredienser, næringsværdi og CO2-aftryk. Dette kan hjælpe elever og personale med at træffe bevidste valg og 
> forstå fødevarens påvirkning på miljøet. Det er meget vigtigt at det bliver nemt at lave den daglige opdatering og at 
> informationerne kun skal skrives ind et enkelt sted. Tænk også på de praktiske udfordringer med vådt miljø og hygiejne.
<p align="right">(<a href="#top">back to top</a>)</p>

# Requirements
- [X] Vise ugens menu
- [X] Vise CO2-aftryk på retterne
- [x] Vise næringsværdig (kcal/kj) på retter
- [x] Vise eventuelle allergener
- [X] Holde opdatering af menu enkelt og centralt
- [x] Tænke hygiejne ind i projektet 
<p align="right">(<a href="#top">back to top</a>)</p>

# Architecture diagram
![architecture diagram](/DOCS/Canteen-Architecture-Diagram.drawio.png)

# Roadmap
- [X] Vise ugens menu
  - [x] Vise CO2-aftryk på retter
  - [x] Vise næringsværdi på retter (pr. 100 gram)
  - [x] Vise eventuelle allergener
  - [x] Vise om retten er vegetarisk eller vegansk
- [x] Opdatere menuen centralt
  - [x] Holde opdateringen enkel
- [ ] Holde systemet hygiejnisk 
  * Dette er ikke med i demo, men der er påtænkt en løsning hvori dette bliver taget højde for i rapporten.


#  Summary and rundown
DOOM er lavet som et proof-of-concept hvori at skolernes kantine kan få et enkelt interface til at vise en ugemenu.

Systemet er lavet som et "standalone" system, det kræver derfor ikke nogen ekstern API eller lign., men er styret via 
sin egen centrale database. Infoskærmen vil vise ugens menu, og automatisk opdatere når personaler lavet ændringer i menuen.

Det er tiltænkt at hele interfacet skal være så simpelt og enkelt som muligt, og derved lette arbejdsgangen for personalet.
<p align="right">(<a href="#top">back to top</a>)</p>


# Getting started
For at komme igang med programmet, kræver det fire steps.
1. Opsæt Azure CLI
2. Databaseopsætning
   1. Installer database jf. SQL script der findes under `/SETUP`
   2. Opret bruger og giv de korrekte privileges
3. Frontend opsætning
   1. Inden opstart skal connection string til databasen eventuelt rettes. Den findes under `/Canteen.Repositories/Context/DBContext.cs`
```csharp
  var cnString = "server=10.131.15.57;user=program;password=SuperSecretPassword1337;database=DOOM";
```
<p align="right">(<a href="#top">back to top</a>)</p>

# Libraries
## Canteen.Blazor
| Name                                              | Version |
| :------------------------------------------------ | :------ |
| Azure.Extensions.AspNetCore.Configuration.Secrets | 1.0.0   |
| Azure.Identity                                    | 1.6.0   |
| Blazored.Modal                                    | 7.1.0   |
| Blazored.Toast                                    | 4.1.0   |
| Microsoft.AspNetCore.Authentication.OpenIdConnect | 7.0.11  |
| Microsoft.Identity.Web                            | 2.13.4  |
| Microsoft.Identity.Web.MicrosoftGraph             | 2.13.4  |
| Microsoft.Identity.Web.UI                         | 2.13.4  |
| Radzen.Blazor                                     | 4.15.14 |
| Seq.Extensions.Logging                            | 6.1.0   |
| Toolbelt.Blazor.HotKeys2                          | 3.0.0   |
| Toolbelt.Blazor.I18nText                          | 12.0.2  |

## Canteen.Repositories
| Name                             | Version |
| :------------------------------- | :------ |
| Microsoft.EntityFrameworkCore    | 7.0.11  |
| Pomelo.EntityFrameworkCore.MySql | 7.0.0   |
<p align="right">(<a href="#top">back to top</a>)</p>


# Database Diagram

![DBDiagram.png](DOCS%2FDBDiagram.png)
<p align="right">(<a href="#top">back to top</a>)</p>

# Flowcharts
![alarm flowchart](/Docs/Alarm_Flowchart.png)
`/Docs/Alarm_Flowchart.png`
<p align="right">(<a href="#top">back to top</a>)</p>


# License
* Frontend: MIT
<p align="right">(<a href="#top">back to top</a>)</p>

# Contact
- Peter Hymøller - peterhym21@gmail.com
  - [![Github][github-peter]][github-peter-link]
- Nicolai Heuck - nicolaiheuck@gmail.com
  - [![Github][github-nicolai]][github-nicolai-link]
- Jan Andreasen - jan@tved.it
  - [![Github][github-jan]][github-jan-link]

Project Link: [https://github.com/nicolaiheuck/Canteen.Blazor/](https://github.com/nicolaiheuck/Canteen.Blazor/)
<p align="right">(<a href="#top">back to top</a>)</p>



<!-- MARKDOWN LINKS & IMAGES -->
<!-- https://www.markdownguide.org/basic-syntax/#reference-style-links -->
[build-shield]: https://img.shields.io/badge/Build-passed-brightgreen.svg
[test-shield]: https://img.shields.io/badge/Tests-passed-brightgreen.svg
[contributors-shield]: https://img.shields.io/github/contributors/nicolaiheuck/Canteen.Blazor.svg?style=badge
[contributors-url]: https://github.com/nicolaiheuck/Canteen.Blazor/graphs/contributors
[forks-shield]: https://img.shields.io/github/forks/nicolaiheuck/Canteen.Blazor.svg?style=badge
[forks-url]: https://github.com/nicolaiheuck/Canteen.Blazor/network/members
[issues-shield]: https://img.shields.io/github/issues/nicolaiheuck/Canteen.Blazor.svg?style=badge
[closed-shield]: https://img.shields.io/github/issues-closed/nicolaiheuck/Canteen.Blazor?label=%20
[issues-url]: https://github.com/nicolaiheuck/Canteen.Blazor/issues
[license-shield]: https://img.shields.io/github/license/nicolaiheuck/Canteen.Blazor.svg?style=badge
[license-url]: https://github.com/nicolaiheuck/Canteen.Blazor/blob/master/LICENSE
[github-peter]: https://img.shields.io/badge/Peter_Hymøller-green?logo=Github&label=Github
[github-peter-link]: https://github.com/peterhym21
[github-nicolai]: https://img.shields.io/badge/Nicolai_Heuck-green?logo=Github&label=Github
[github-nicolai-link]: https://github.com/nicolaiheuck
[github-jan]: https://img.shields.io/badge/Jan_Andreasen-green?logo=Github&label=Github
[github-jan-link]: https://github.com/Thoroughbreed

