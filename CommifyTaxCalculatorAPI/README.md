# Commify Income Tax Calculator

Welcome! Please begin by trusting the dev-certs.

`dotnet dev-certs https --trust`

After which you can run `dotnet run --launch-profile https`, presumably alongside the UI.

## Why DTOs and Models?

While for the most part the Models and DTOs are the same, having data returned from the Database and data that is returned via the API kept separate will help prevent future additions from unintentionally being exposed.
