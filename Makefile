install:
	dotnet restore src/App
	dotnet tool restore

setup: install
	dotnet publish src/App -c Release -o dist

run-dist:
	./dist/App

run:
	dotnet run --project src/App

lint:
	dotnet csharpier check .

lint-fix:
	dotnet csharpier format .
