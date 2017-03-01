module.exports =
    {
        accessionState: {
            loaded: false,
            isNew: false,
            isLoadingClientsAsync: false,
            accession: {
                "id": 0,
                "guid": "00000000-0000-0000-0000-000000000000",
                "clientId": 0,
                "facilityId": 0,
                "patientId": 0,
                "mrn": '',
                "orderingLabId": 0,
                "createdDate": "02/27/2017",
                "specimens": [
                  {
                      attributesAreSet: false,
                      "guid": "00000000-0000-0000-0000-000000000000",
                      "id": 0,
                      "externalSpecimenID": '',
                      "code": "",
                      "parentSpecimenId": 0,
                      "type": "",
                      "transport": "",
                      "collectionDate": "01/01/1900",
                      "receivedDate": "01/01/1900",
                      "customData": {
                          "attributes": [
                              {
                                  "name": "",
                                  "value": ""
                              }
                          ],
                      }
                  }
                ],
                "cases": [
                  {
                      "guid": "00000000-0000-0000-0000-000000000000",
                      "id": 0,
                      "caseNumber": '',
                      "type": "",
                      "processingLabID": 0,
                      "analysisLab": 0,
                      "professionalLabID": 0,
                      "customData": {},
                      "specimenGuids": ["00000000-0000-0000-0000-000000000000", ],
                      "panelResults": [
                        {
                            "id": 0,
                            "guid": "00000000-0000-0000-0000-000000000000",
                            "panelName": '',
                            "customData": {}
                        }
                      ],
                      "testResults": [
                        {
                            "id": 0,
                            "guid": "00000000-0000-0000-0000-000000000000",
                            "testName": '',
                            "customData": {}
                        }
                      ]
                  }
                ]
            },
            clients: [
                {
                    "id": 0,
                    "name": '',
                    "facilities": [
                        {
                            "id": 0,
                            "name": ''
                        }],
                },
            ]            
        }
    };