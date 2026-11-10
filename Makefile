install:
	dotnet restore src/App

setup: install
	dotnet publish src/App -c Release -o dist

run-dist:
	./dist/App

run:
	dotnet run --project src/App