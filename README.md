# Simple Game Store Web Application

A simple game store web application in asp.net core 6

## Table of contents
* [General info](#general-info)
* [Tech Stack](#technologies)
* [Application architecture](#application-architecture)
* [Setup](#setup)
* [Unit tests](#unit-tests)
* [Not implemented](#not-implemented)
* [Conclusion](#conclusion)

## General info
The goal of the project is to learn how to develop a commercial application.
	
## Tech Stack
Project is created with:
* ASP.Net Core 6
* EF core 6
* Visual Studio version: 2022
* .Net Core version: 6
* MSSqlserver 2019

## Application architecture
Architecture of this project is Three-Tier Architecture.
* Presentation Layer
* Business Logic Layer(BLL)
* Data Access Layer(DAL)

### Data Layer
The MSSQLServer used as data layer
### Data Access Layer(DAL)
On top of the Data layer located Data Access Layer, which consists of two type classes. A set of classes to represent the Tables are ApplicationUser, BaseEntity, Comment, Game, GameGenre, Genre.
### Business Logic Layer(BLL)
The BLL will have a reference to the DAL. BLL manages the Input and output between DAL and Presentation LayerBusiness Logic Layer consists of Interfaces and Services to perform CRUD operaions.
#### Interfaces
* ICrud
* ICommentService.cs
* IGameService.cs
* IGenreService.cs
#### Services
* CommentService.cs
* GameService.cs
* GenreService.cs
### Presentation Layer
It is a web apllication on asp.net mvc core 6.
	
## Setup

## Unit Tests

## Not implemented
* Unit Tests
* Setup


## Conclusion
In this project, i have learned:
* Create ASP.NET Applications with N-Tier Architecture.
* Use CRUD operations.
* Use HttpPost and HttpGet.
* Explore MVC.
* Work with Sessions
* Automapper
* Identity
* Work with ViewModels
