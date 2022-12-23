# cleancode-labb2-fat

[Database diagram](https://drive.google.com/file/d/1wB6NgBqBcbWlpGmi5RmCkFG-Gyrc5Xm_/view?usp=sharing)

# API Endpoints

## api/pizza

 Endpoint | Method | Request | Response | Query | Codes | Description 
|-|-|-|-|-|-|-|
pizza | POST | Pizza | Pizza | | 201, 400, 409 | Adds a new pizza
pizza | GET | | List of pizzas | | 200, 404 | Retrieves all pizzas 
pizza/{id} | GET | | Pizza | | 200, 404 | Retrieves a pizza with the specified ID 
pizza/{id}/orders | GET | | List of orders | | 200, 404 | Retrieves all orders containing the supplied pizza ID 
pizza/{id} | PUT | Pizza | Pizza | | 200, 400, 404 | Updates a pizza with the specified ID 
pizza/{id}/ingredients | PATCH | List of ingredient(s) | Pizza | | 200, 400, 404 | Modifies ingredients in a pizza with the supplied ID 
pizza/{id} | DELETE | | Pizza | | 200, 400, 404 | Deletes a pizza with the specified ID 

## api/order

| Endpoint | Method | Request | Response | Query | Codes | Description |
|-|-|-|-|-|-|-|
orders | POST | Order | Order | | 201, 400, 409 | Adds a new order
orders | GET | | List of orders | | 200, 404 | Retrieves all orders 
orders/{id} | GET | | Order | | 200, 404 | Retrieves a order with the specified ID 
orders/{id} | PUT | Order| Order | | 200, 400, 404 | Updates a order with the specified ID 
orders/{id}/pizzas | PATCH | List of Pizza(s) | Order | | 200, 400, 404 | Modifies pizzas in a order with the supplied ID
orders/{id} | DELETE | | Order | | 200, 400, 404 | Deletes a order with the specified ID 

## api/ingredient

| Endpoint | Method | Request | Response | Query | Codes | Description |
|-|-|-|-|-|-|-|
ingredients/ | POST | Ingredient | Ingredient | | 201, 400, 409 | Creates a new Ingredient
ingredients | GET | | List of ingredients | | 200, 404 | Retrieves all ingredients 
ingredients/{id} | GET | | Ingredient | | 200, 404 | Retrieves a ingredient with the specified ID 
ingredients/{id}/pizzas | GET | | List of pizzas | | 200, 404 | Retrieves all pizzas containing the supplied ingredient ID
ingredients/{id}/name | PATCH | | Ingredient | string value | 200, 400, 404, 409 | Modifies the name of a ingredients with the supplied ID
ingredients/{id} | DELETE | | Ingredient | | 200, 400, 404 | Deletes a ingredient with the specified ID 
