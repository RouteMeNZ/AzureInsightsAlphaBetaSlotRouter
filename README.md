# AzureInsightsAlphaBetaSlotRouter

This project is an opinionated A/B testing library for people using Azure with Application insights. We are using the Azure application insights REST API and various gang of four patterns to write an extensible framework for A/B testing with application insights.

The project uses www.specflow.org for testing to describe clearly in BDD format what our various tests are doing so that people can understand are reuse them as they require.

## Getting started

To get started we recommend doing the following:

* Download specflow from www.specflow.org
* Install the required version of the .net core SDK. This project currently uses the 1.0.1 version as of writing this. The version can be seen in the various project.json files if you are unsure.
* Read through the gherkin syntax in the specflow
* 

## Who uses it currently?

This project is used by www.routeme.co.nz to help deliver RouteMe's code via A/B testing mechanisms. For us A/B testing spans marketing objectives and operational stability. We use Azure application insights for both and thus use the same process for both. You too can use our framework for any A/B testing you want against Application Insights with ease.

## Trouble shooting

Note you many need to adjust your Azure application insights plan for some of the tests to work (because of the way Azure prices their insights API; coupling it with the non API application insights).