# Movie-App API

**Version:** 1.0  
**Description:** A Movie Management System that allows managing genres, movies, and user authentication through RESTful API endpoints. This project is built to handle core operations such as adding, editing, listing, and deleting data.

## Table of Contents
- [Features](#features)
- [Technologies](#technologies)
- [Setup](#setup)
- [API Endpoints](#api-endpoints)
  - [Genre Endpoints](#genre-endpoints)
  - [Movie Endpoints](#movie-endpoints)
  - [User Authentication Endpoints](#user-authentication-endpoints)
  - [Home Endpoints](#home-endpoints)
- [Schemas](#schemas)

---

## Features
- Add, edit, and manage genres and movies.
- Secure user registration and login.
- Fetch movie details, including casts, genres, and release year.
- Comprehensive API documentation using Swagger UI.

---

## Technologies
- **ASP.NET Core**: Framework for building the API.
- **Swagger/OpenAPI**: For API documentation and testing.
- **JSON**: For structured data exchange.

---

## Setup

### Prerequisites
- Install [Visual Studio](https://visualstudio.microsoft.com/) or [Rider](https://www.jetbrains.com/rider/).
- Install the .NET 8 SDK.

### Steps
1. Clone the repository:
   ```bash
   git clone https://github.com/GbohunmiFrancis/movie-app.git
   cd movie-app
API Endpoints
Genre Endpoints
Method	Endpoint	Description
GET	/api/Genre/add	Fetch the genre addition form.
POST	/api/Genre/add	Add a new genre.
GET	/api/Genre/edit/{id}	Get genre details for editing by ID.
PUT	/api/Genre/update	Update an existing genre.
GET	/api/Genre/list	List all genres.
DELETE	/api/Genre/delete/{id}	Delete a genre by ID.
Movie Endpoints
Method	Endpoint	Description
POST	/api/Movie/add	Add a new movie.
PUT	/api/Movie/edit/{id}	Update an existing movie by ID.
GET	/api/Movie/list	List all movies.
DELETE	/api/Movie/delete/{id}	Delete a movie by ID.
User Authentication Endpoints
Method	Endpoint	Description
POST	/api/UserAuthentication/login	Log in with username and password.
POST	/api/UserAuthentication/register	Register a new user.
POST	/api/UserAuthentication/logout	Log out a user.
Home Endpoints
Method	Endpoint	Description
GET	/api/Home/index	Fetch the home index page (supports search and pagination).
GET	/api/Home/about	Get details about the app.
GET	/api/Home/moviedetail/{movieId}	Get detailed information about a movie by ID.
Schemas
Genre Schema
json
Copy code
{
  "id": "integer",
  "genreName": "string"
}
Movie Schema
Required Fields:

Cast
Director
Genres
Title
Example:

json
Copy code
{
  "Id": 1,
  "Title": "Inception",
  "ReleaseYear": "2010",
  "MovieImage": "image.jpg",
  "Cast": "Leonardo DiCaprio, Joseph Gordon-Levitt",
  "Director": "Christopher Nolan",
  "Genres": [1, 2],
  "GenreNames": "Action, Sci-Fi"
}
Login Schema
json
Copy code
{
  "username": "string",
  "password": "string"
}
Registration Schema
Required Fields:

name
email
password
passwordConfirm
Example:

json
Copy code
{
  "name": "John Doe",
  "email": "johndoe@example.com",
  "username": "johndoe123",
  "password": "P@ssw0rd",
  "passwordConfirm": "P@ssw0rd"
}
License
This project is licensed under the MIT License.
