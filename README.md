<a name="readme-top"></a>

[![Contributors][contributors-shield]][contributors-url]
[![Stargazers][stars-shield]][stars-url]
[![Issues][issues-shield]][issues-url]
[![LinkedIn][linkedin-shield]][linkedin-url]

<!-- PROJECT LOGO -->
<br />
<div align="center">
  <a href="https://github.com/Dulcey93/MvcProductCrud">
    <img src="MvcProductCrud/wwwroot/images/trolley.png" alt="Logo" width="80" height="80">
  </a>

  <h3 align="center">MvcProductCrud</h3>

  <p align="center">
    A simple but powerful CRUD application built with ASP.NET Core MVC and MySQL.
    <br />
    <a href="https://github.com/Dulcey93/MvcProductCrud"><strong>Explore the docs »</strong></a>
    <br />
    <br />
    <a href="https://github.com/Dulcey93/MvcProductCrud">View Demo</a>
    ·
    <a href="https://github.com/Dulcey93/MvcProductCrud/issues">Report Bug</a>
    ·
    <a href="https://github.com/Dulcey93/MvcProductCrud/issues">Request Feature</a>
  </p>
</div>

<details>
  <summary>Table of Contents</summary>
  <ol>
    <li>
      <a href="#about-the-project">About The Project</a>
      <ul>
        <li><a href="#built-with">Built With</a></li>
      </ul>
    </li>
    <li>
      <a href="#getting-started">Getting Started</a>
      <ul>
        <li><a href="#prerequisites">Prerequisites</a></li>
        <li><a href="#installation">Installation</a></li>
      </ul>
    </li>
    <li><a href="#usage">Usage</a></li>
    <li><a href="#roadmap">Roadmap (Day by Day)</a></li>
    <li><a href="#contact">Contact</a></li>
    <li><a href="#acknowledgments">Acknowledgments</a></li>
  </ol>
</details>

## About The Project

<img src="MvcProductCrud/wwwroot/images/images/trolley.png" alt="Demo Screenshot" width="100%" />

This project was developed by @Dulcey93 as part of a personal learning journey with ASP.NET Core MVC. The application demonstrates a complete CRUD (Create, Read, Update, Delete) workflow connected to a MySQL database.

It is also a foundation to explore advanced features like:
- ViewModel validation
- Image/file uploads
- Bootstrap 5 integration
- Azure App Service deployment

<p align="right">(<a href="#readme-top">back to top</a>)</p>

### Built With

* ![ASP.NET Core](https://img.shields.io/badge/ASP.NET_Core-512BD4?style=for-the-badge&logo=.net&logoColor=white)
* ![MySQL](https://img.shields.io/badge/MySQL-4479A1?style=for-the-badge&logo=mysql&logoColor=white)
* ![Bootstrap](https://img.shields.io/badge/Bootstrap-563D7C?style=for-the-badge&logo=bootstrap&logoColor=white)

<p align="right">(<a href="#readme-top">back to top</a>)</p>

## Getting Started

To get a local copy up and running, follow these simple steps.

### Prerequisites

You need to have installed:

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- [MySQL Community Server](https://dev.mysql.com/downloads/mysql/)
- [MySQL Workbench](https://www.mysql.com/products/workbench/)
- [Visual Studio 2022+](https://visualstudio.microsoft.com/)

### Installation

1. Clone the repository:
   ```bash
   git clone https://github.com/Dulcey93/MvcProductCrud.git
   cd MvcProductCrud
   ```
2. Update your MySQL connection string in `appsettings.json`
3. Create the database and apply migrations:
   ```bash
   dotnet ef migrations add InitialCreate
   dotnet ef database update
   ```
4. Run the app:
   ```bash
   dotnet run
   ```

<p align="right">(<a href="#readme-top">back to top</a>)</p>

## Usage

You can access the application at:
```
https://localhost:xxxx/Products
```

Basic features include:
- Add a new product
- Edit an existing product
- Delete a product
- View the full product list

<p align="right">(<a href="#readme-top">back to top</a>)</p>

## Roadmap (Day by Day)

- [x] Day 1: Setup, model, DbContext, migration, CRUD views
- [ ] Day 2: ViewModel validation, file/image upload, Bootstrap 5 integration, Azure deployment
- [ ] Day 3: Identity + Authentication, Roles, Filtering + Searching
- [ ] Day 4: API endpoints + Swagger + Docker + CI/CD pipeline

<p align="right">(<a href="#readme-top">back to top</a>)</p>

## Contact

Santiago Dulcey - [@Dulcey93](https://github.com/Dulcey93)  
Project Link: [https://github.com/Dulcey93/MvcProductCrud](https://github.com/Dulcey93/MvcProductCrud)

<p align="right">(<a href="#readme-top">back to top</a>)</p>

## Acknowledgments

* [ASP.NET Docs](https://learn.microsoft.com/en-us/aspnet/core/)
* [MySQL Connector for EF Core](https://www.nuget.org/packages/Pomelo.EntityFrameworkCore.MySql)
* [Bootstrap Documentation](https://getbootstrap.com/)
* [Img Shields](https://shields.io)
* [GitHub Pages](https://pages.github.com)
* [Font Awesome](https://fontawesome.com)

<p align="right">(<a href="#readme-top">back to top</a>)</p>

[contributors-shield]: https://img.shields.io/github/contributors/Dulcey93/MvcProductCrud.svg?style=for-the-badge
[contributors-url]: https://github.com/Dulcey93/MvcProductCrud/graphs/contributors
[stars-shield]: https://img.shields.io/github/stars/Dulcey93/MvcProductCrud.svg?style=for-the-badge
[stars-url]: https://github.com/Dulcey93/MvcProductCrud/stargazers
[issues-shield]: https://img.shields.io/github/issues/Dulcey93/MvcProductCrud.svg?style=for-the-badge
[issues-url]: https://github.com/Dulcey93/MvcProductCrud/issues
[linkedin-shield]: https://img.shields.io/badge/-LinkedIn-black.svg?style=for-the-badge&logo=linkedin&colorB=555
[linkedin-url]: https://www.linkedin.com/in/dulcey93
