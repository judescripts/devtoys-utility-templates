# [DevToys.io](https://devtoys.io)

## DotNet TAB Stack Template

## Installation

This is a **T**ailwindCSS, **A**zure, **B**lazor (**TAB**) stack template to get you started on your dev journey fast!

- Install the Nuget Package for DevToys.Tab-Tamb templates
```dotnet new install DevToys.TabTamb```
- Run ``` npm i ```
- If run-tailwind.ps1/run-tailwind.sh hasn't run manually run the task (vscode), open the Task Runner (visual studio) or the script itself.
- ``` dotnet watch run ``` (vscode) or ``` F5 ``` run the project (vs)

## Features

When opening the project in VS or VScode ./run-tailwind.ps1 task will run automatically and close automatically when the project closes. You can change this behavior with updating the tasks.json (vscode) or package.json (visual studio). For automatic script runs in visual studio you need to install [NPM Task runner](https://marketplace.visualstudio.com/items?itemName=MadsKristensen.NPMTaskRunner)

| Packages | Website | Version |
| ------ | ------ | ----- |
| TailwindCss | <https://tailwindcss.com/> | 3.4.1
| Azure Identity | <https://www.nuget.org/packages/Azure.Identity> | 8.0.1
| Azure Key Vault | <https://www.nuget.org/packages/Azure.Security.KeyVault.Secrets> | 8.0.1
| Blazor (.NET 8) | <https://dotnet.microsoft.com/en-us/apps/aspnet/web-apps/blazor> | 8.0.1
| EF Core SQL | <https://www.nuget.org/packages/Microsoft.EntityFrameworkCore/8.0.1> | 8.0.1
___

**Project starts with a sample dashboard utilizing tailwindcss like below**
 ![Dashboard Sample](./sample_dashboard.png "Dashboard Sample")

## Development

Feel free to 🍴 Fork and contribute!

## License

MIT
