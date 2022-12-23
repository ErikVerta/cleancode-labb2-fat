# cleancode-labb2-fat

[Database diagram](https://drive.google.com/file/d/1wB6NgBqBcbWlpGmi5RmCkFG-Gyrc5Xm_/view?usp=sharing)

# API Endpoints

## api/pizza

 Endpoint | Method | Request | Response | Query | Codes | Description 
|-|-|-|-|-|-|-|
pizza | POST | Pizza | Pizza | | 200, 400 | Adds a new pizza
pizza | GET | | List of pizzas | | 200 | Retrieves all pizzas 
pizza/{id} | GET | | Pizza | | 200, 400 | Retrieves a pizza with the specified ID 

## api/order

| Endpoint | Method | Request | Response | Query | Codes | Description |
|-|-|-|-|-|-|-|
orders | POST | Order | Order | | 200, 400 | Adds a new order
orders | GET | | List of orders | | 200 | Retrieves all orders 
orders/{id} | GET | | Order | | 200, 400 | Retrieves a order with the specified ID

## api/ingredient

| Endpoint | Method | Request | Response | Query | Codes | Description |
|-|-|-|-|-|-|-|
ingredients/ | POST | Ingredient | Ingredient | | 200, 409 | Creates a new Ingredient
ingredients | GET | | List of ingredients | | 200 | Retrieves all ingredients 
ingredients/{id} | GET | | Ingredient | | 200, 404 | Retrieves a ingredient with the specified ID
