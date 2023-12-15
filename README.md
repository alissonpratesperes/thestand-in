___
<p align="center">
    <img src="github/main_logo.png" width="30%"/>
</p>
    <br/>
<p align="center">
    <a href="https://balta.io/"><img alt="Course Instructor" src="https://img.shields.io/badge/instrutor-André%20Baltieri-04ACC5"/></a>
        <img alt="GitHub Language Count" src="https://img.shields.io/github/languages/count/alissonpratesperes/thestand-in?color=04ACC5"/>
        <img alt="Top Language" src="https://img.shields.io/github/languages/top/alissonpratesperes/thestand-in?color=04ACC5"/>
    <a href="https://github.com/alissonpratesperes/thestand-in"><img alt="Repository Stacking" src="https://img.shields.io/badge/repository%20stacking-API-04ACC5"/></a>
    <a href="https://github.com/alissonpratesperes/thestand-in/commits/main"><img alt="GitHub Last Commit" src="https://img.shields.io/github/last-commit/alissonpratesperes/thestand-in?color=04ACC5"/></a>
    <a href ="https://github.com/alissonpratesperes/thestand-in/blob/main/LICENSE"><img alt="GitHub License" src="https://img.shields.io/badge/license-MIT-04ACC5"/>
</p>
    <br/>
<p align="center">
    <a href="#dart-sobre">Sobre</a>&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;
    <a href="#battery-tecnologias">Tecnologias</a>&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;
    <a href="#electric_plug-execute">Execute</a>&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;
    <a href="#bulb-design">Design</a>&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;
    <a href="#fuelpump-autor">Autor</a>&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;
    <a href="#memo-licença">Licença</a>
</p>
    <br/>

## :dart: Sobre
A **The Stand-in** é uma Aplicação envolvendo uma plataforma de encontros online, *que foi inspirada no filme: O Date Perfeito*, e que ajuda pessoas a encontrarem seus Dates Perfeitos online.

## :battery: Tecnologias
Essa Aplicação foi desenvolvida utilizando as seguintes tecnologias:
- <a href="https://dotnet.microsoft.com/en-us/apps/aspnet/web-apps/">C#</a>
- <a href="https://dotnet.microsoft.com/en-us/">.NET Core</a>
- <a href="https://learn.microsoft.com/en-us/ef/">EF Core</a>
- <a href="https://www.nuget.org/packages/Dapper">Dapper</a>
- <a href="https://sqlite.org/">SQLite 3</a>
- <a href="https://swagger.io/">Swagger</a>
- <a href="https://insomnia.rest/">Insomnia</a>

## :electric_plug: Execute
    - Clonar o Repositório:
        |- Acessar o diretório da camada 'Application' com o comando: ">_ cd backend/Application";
            > Inicializar o Back-End com o comando: ">_ dotnet <watch?> run".

## :bulb: Design
    COMPLETION OF COURSE PROJECT | C# .NET Back-End Developer | André Baltieri - Balta.io | DONE: true

    The Stand-in: Find your perfect date. {
        "title": "The Stand-in: Find your perfect date.",
        "goal": "Development of an App, with the concepts covered in the course, and easy for anyone to interact with.",
        "back-end": "With only one command to run it, the App must be started completely, without any other interaction.",
        "tables": [
            Prospect {
                Description: "Who will attend the requested Dates."

                    "Name", ============================> |Brooks Rattigan| <string>
                    "Goal", ============================> |15000| <decimal>
                    "Contact", =========================> |+5554991768785| <string>
                    "Biography", =======================> |Pobretão de Breachport, querendo dinheiro pra faculdade| <string>
                    "Situation": <ValueObject> {
                        "Active", ======================> |True| <boolean>
                        "Available" ====================> |True| <boolean>
                    },
                    "Date of Birth", ===================> |1996-05-09| <dateonly>
                    "ProfilePicture": {
                        Extension Method for Upload ====> |File.jpg| <base 64 | string>
                    },

                        "Dates" ========================> List<IReadOnlyCollection<Date>>

                Commands: Create, Read, Update, Delete
                Queries: List, Get
            },
            Date {
                Description: "Who will request the Dates to the Prospects."

                    "Name", ============================> |Celia Lieberman| <string>
                    "Title", ===========================> |Companhia para a festa da Shelby Pace| <string>
                    "Status": <ExtensionMethod>, =======> |Requested| <enumerator| EStatus>
                    "Contact", =========================> |+5554991768785| <string>
                    "Schedule", ========================> |2023-06-16T19:30:00| <datetime>
                    "Location": <ValueObject> {
                        "Latitude", ====================> |28.9669647| <string>
                        "Longitude" ====================> |51.0436304| <string>
                    },
                    "Description", =====================> |Festa da Shelby, para eu conversar com o Frank| <string>
                    "Displacement": <ExtensionMethod>, => |Need| <enumerator| EDisplacement>
                    "Contribution", ====================> |3000| <decimal>

                        "ProspectId" ===================> |Brooks Rattigan| <string>

                Actions: Request, Accept, Finish, Refuse
                Commands: Create, Read, Update, Delete
                Queries: List, Get
            }
        ],
        "enumerators": [
            EDisplacement {
                "Need", =======> Needs a ride
                "Give", =======> Gives a ride
                "Outer" =======> We both meet

                    Extension Method: Displacement
            },
            EStatus {
                "Requested", ==> Waiting to be accepted
                "Happening", ==> Running after accepted
                "Completed", ==> Finished by a Prospect
                "Declined" ====> Declined by a Prospect

                    Extension Method: Status
            }
        ],
        "validations": [
            Prospect {
                "Update", => prospect.Dates.Count(d => d.Status == EStatus.Requested) > 0
                "Delete" ======================================> prospect.Dates.Count > 0
            },
            Date {
                "Create", =============================> prospect.Status.Available = true
                "Update", =============================> date.Status != EStatus.Requested
                "Delete" ==============================> date.Status != EStatus.Requested
            }
        ],
        "improvements": [
            { "Os Commands e Handlers base devem ser Interfaces sendo implementadas em outros." },
            { "Deve ser implementado o Rollback para o Banco de Dados das Exceptions lançadas." },
            { "Try/Catch Blocks devem implementar Rollbacks nos Handlers para operações deles." },
            { "Todo Serviço é registrado na Classe 'Program.cs' separado em Extension Methods." },
            { "Os resultados dos 'Commands' devem ser padronizados seguindo Extension Methods." },
            { "Os Uploads das Pictures dos Prospects são padronizados pelos Extension Methods." },
            { "Será implementado um Value Object pelo menos numa Propriedade destas Entidades." },
            { "Deverá ser implementados os Extension Methods em todos Enumeradores principais." },
            { "Deverá ser implementada a Paginação dos Dados de ViewModels distintas Get/List." },
            { "No List/Get das Entidades, ViewModels serão implementadas tipo os ValueObjects." },
            { "Será implementada a filtragem em pelo menos uma Propriedade das duas Entidades." }
        ],
        "obligations": [
            { "Inicializar o repositório no GitHub, deverá seguir o padrão Monolito." },
            { "Os Commits deverão possuir assertividade evitando redundâncias neles." },
            { "Documentar commits, o repositório servirá para anotações e consultas." },
            { "O Inglês será o idioma padrão, tanto para Código como para Interface." },
            { "A API toda deve ter todos os endpoints documentados tecnicizadamente." },
            { "Implementar o README documental da Aplicação, após o desenvolvimento." }
        ],
        "patterns": [
            { "CQRS Sample, como padrão de projeto segmentando Comandos | Consultas." },
            { "Code First, database será gerado e atualizado através das Migrations." },
            { "O Banco de Dados deverá ser migrado de forma autônoma pela aplicação." },
            { "Padronização das requisições será feita usando implementação MediaTR." },
            { "Interfaces ICommand, IHandler abstraídas para uso do MediaTR Pattern." },
            { "Interfaces IQuery, IQueryHandler abstraídas para uso MediaTR Pattern." },
            { "ViewModel GET diferirá das ViewModel List, devido à cargas dos dados." },
            { "As Pictures dos Prospects servidas estaticamente na URL dos Browsers." },
            { "Implementar Caching para a camada das Queries para as duas Entidades." }
        ],
        "responsabilities": [
            { "stack": "backend", "task": "Receber e tratar todas requisições acontecidas." },
            { "stack": "database", "task": "Acumular e relacionar todos registros criados." }
        ],
        "technologies": [
            { "stack": "backend",  "language": "C#",   "framework": "dotNET" },
            { "stack": "database", "language": "SQL",  "framework": "SQLite" }
        ],
        "deliveries": [
            { "stack": "back-end", "prioridade": 0 },
            { "stack": "database", "prioridade": 1 }
        ]
    }

## :fuelpump: Autor
Este Projeto foi desenhado e desenvolvido de forma autônoma, a fim de ser um "**trabalho de conclusão de curso**" próprio e personalizado, e com o objetivo de constituir uma POC, ou seja, uma Prova de Conceito da implementação de todas as técnicas e conceitos abordados durante a formação, portanto constitui-se neste repositório, apenas a camada de Back-End propriamente dita. Mediante a finalização do Curso **.NET Back-End Developer** do <a href="https://balta.io/">André Baltieri</a>, realizado em **Outubro de 2022**.

## :memo: Licença
Esse projeto está sob a **Licença MIT**. Veja o arquivo [LICENSE](https://github.com/alissonpratesperes/thestand-in/blob/main/LICENSE) para mais detalhes.

___

<h5 align="center">✍🏼&nbsp;com&nbsp;🔥&nbsp;por&nbsp;<a href="https://github.com/alissonpratesperes">Alisson Prates Peres</a>&nbsp;🙋🏻‍♂️</h5>