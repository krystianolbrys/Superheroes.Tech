# Superheroes Tech Test

Welcome and congratulations on getting to Stage 2. Please familiarise yourself with this test and feel free to ask any questions and use online help during this exercise. Please be aware that we value the quality of the code and solution over completed exercise that is breaking principles. We will be especially looking for:
- Best practices
- SOLID, DRY, OOP, YAGNI principles
- Effective code
- Structure of the project
- Working Solution
- Unit Tests

# Introduction

Superheroes and supervillains are always battling it out, but how do we know who wins? In this exercise we will ask you to build a simple API that gives us that answer. The API should contain an endpoint which takes a hero and a villain and returns the character that wins. 

The characters and their stats are stored in a json format - https://gist.githubusercontent.com/arturfie/1594a132dbf76a977503136a5b928e92/raw/a83cdb719e0d80093ce69100009477692a06e4be/characters.json \
The character with a bigger score wins.

## Feature 1 - Battle API

Please provide an endpoint which takes a character and their rival and returns one that wins.

#### Acceptance Criteria:
1. Should return Thanos - http://localhost:5000/battle?character=Thor&rival=Thanos


## Feature 2 - Validation

Superheroes can obviously only fight supervillains and vice versa. 
Add some validation to make sure that only this can happen (no villain vs villain or hero vs hero fights).

#### Acceptance Criteria
2. Should return 400 "characters of the same type should not fight" - http://localhost:5000/battle?character=Batman&rival=Superman