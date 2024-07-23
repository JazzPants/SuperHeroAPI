#SuperHeroAPI (.NET)

## How to use the API (standalone)
VSCode users:
1. Clone this repo to your local machine.
2. Open this folder in VSCode.
3. Open a new terminal.
4. run `dotnet run` and wait for it to finish building
5. Run this link `https://localhost:7203/swagger/index.html`
6. Try the different CRUD requests with the Swagger UI!
   e.g. Select Get, then "Try it out", then execute. The api should return data in a JSON format.

Visual Studio 2022 users:
1. Clone this repo to your local machine.
2. Open this folder in Visual Studio 2022
4. select "Run without debugging" button or (press CTRL-F5) and wait for it to finish building
5. Run this link `https://localhost:7203/swagger/index.html` or wait for it to open automagically in your currently open internet browser.
6. Try the different CRUD requests with the Swagger UI!
   e.g. Select Get, then "Try it out", then execute. The api should return data in a JSON format.


## How to use the API with front-end "SuperHeroUI"

1. Clone the SuperHeroUI repo and this repo.
2. Run both repos locally (npm run ng serve or ng serve for SuperHeroUI, and dotnet run for SuperHeroAPI)
3. Open link `http://localhost:4200/` to access the front-end UI
4. Experiment with the different features (more instructions at: https://github.com/JazzPants/SuperHero.UI/tree/main)
