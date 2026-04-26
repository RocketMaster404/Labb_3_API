/api/Users - Hämta alla användare i systemet
{
    "firstName": "Erik",
    "lastName": "Larsson",
    "phoneNumber": "0701111111",
    "email": "erik@mail.com"
  },

  /Api/Users{Id} - Hämta alla intressen kopplade till en specifik person (söks på id)

  {
  "firstName": "Erik",
  "lastName": "Larsson",
  "phoneNumber": "0701111111",
  "email": "erik@mail.com",
  "interests": [
    "Climbing",
    "Gaming",
    "Running"
  ]
}

/Api/Users{id}/links -  Hämta alla länkar kopplade till en specifik person (Söks på id)

{
  "firstName": "Erik",
  "lastName": "Larsson",
  "interestLinks": [
    {
      "url": "https://climbing.com",
      "title": "Climbing"
    },
    {
      "url": "https://twitch.tv",
      "title": "Gaming"
    },
    {
      "url": "clmbingTest.com",
      "title": "Climbing"
    },
    {
      "url": "Google.com",
      "title": "Climbing"
    }
  ]
}

/Api/Users{userId}/Interests - Koppla en person till ett nytt intresse
UsersId Används i inputfält på Swagger
{
  "interestId": 0  <-- ange ditt interestid 
}

404 - Intresse eller användare finns ej
409 - conflict om användaren redan har intresset (kan ej koppa ett intresse 2ggr)

/Api/Users{id}/links - Lägga till nya länkar för en specifik person och ett specifikt intresse
UserId anges i input fält på swagger
{
  "url": "www.testsson.se",
  "interestID": 1
}


