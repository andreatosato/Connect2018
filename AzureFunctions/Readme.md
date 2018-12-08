Guida del 12/12/2018

##Prepara la soluzione
Funziona con Python 3.6, non con i precedenti e non con i successivi!
```bash
 py -3.6 -m venv .env
 .env\scripts\activate
```

## Create Functions App
```bash
func init Connect2018FuncApp
```

## Create Functions
```bash
cd Connect2018FuncApp
func new
```

## Run locally
```bash
func host start
```


More info: https://docs.microsoft.com/en-us/azure/azure-functions/functions-create-first-function-python