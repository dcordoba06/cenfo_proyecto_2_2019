# Requests para el API.

#CREATE CUSTOMER

URL: http://localhost:57056/api/customer/
METHOD: POST
BODY:

{
    "Id": "333",
    "Name": "Chapulin 33",
    "LastName": "Colorado",
    "Age": 33
}

#RETRIEVE ALL CUSTOMER

URL: http://localhost:57056/api/customer/
METHOD: GET

#RETRIEVE ONE 

URL: http://localhost:57056/api/customer/333
METHOD: GET

#UPDATE CUSTOMER

URL: http://localhost:57056/api/customer/
METHOD: PUT
BODY:

{
    "Id": "333",
    "Name": "Chapulin Colorin",
    "LastName": "Colorado",
    "Age": 33
}

#DELETE CUSTOMER

URL: http://localhost:57056/api/customer/
METHOD: DELETE
BODY:

{
    "Id": "333",
    "Name": "Chapulin 33",
    "LastName": "Colorado",
    "Age": 33
}
