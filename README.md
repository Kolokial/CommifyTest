# Commify Tax Calculator Test

Welcome!

## Running locally

### UI

Navigating to `CommifyTaxCalculatorUI` and running `npm install`, followed by `npm start`. There is an `.nvmrc` file so please run `nvm use` to use the same NPM version.

### API

Navigate to `CommifyTaxCalculatorAPI` and run `dotnet restore`, followed by `dotnet run`.

## Troubleshooting

If the UI does not connect to the API, the port number may need to changed in the proxy setup file, found at [`./CommifyTaxCalculatorUI/src/proxy.conf.json`](./CommifyTaxCalculatorUI/src/proxy.conf.json).
