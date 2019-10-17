Available Routes:


main:

https://exchangeratecalculatorwebapi20191017073631.azurewebsites.net

returns list of available currencies


calculate/{amount}/{currency1}/{currency}:

example:  https://exchangeratecalculatorwebapi20191017073631.azurewebsites.net/calculate/100/usd/eur

calculates given amount from currency1 to currency2


logs/api:


https://exchangeratecalculatorwebapi20191017073631.azurewebsites.net/logs/api

returns list of logs for calls to api


logs/ext


https://exchangeratecalculatorwebapi20191017073631.azurewebsites.net/logs/ext

returns list of logs for calls to external resources, in this case NBP api


