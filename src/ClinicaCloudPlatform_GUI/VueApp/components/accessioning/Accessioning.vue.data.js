module.exports =
    {
        accessionState: {
            loaded: false,
            isNew: false,
            isLoadingClientsAsync: false,
            isLoadingPatientsAsync: false,
            patientsSearched: false,
            accession: {
                "id": 0,
                "client": {
                    "id": 0,
                    "name": ''
                },
                "facility": {
                    "id": 0,
                    "name": ''
                },
                "patient": {
                    "id": 0,
                    "lastName": '',
                    "firstName": '',
                    "ssn": '000-00-000',
                    "dob": '01/01/1900'
                },
                "mrn": '',
                "specimens": [
                  {
                      "id": 0,
                      "externalID": '',
                      "customData": '{}'
                  }
                ],
                "cases": [
                  {
                      "id": 0,
                      "caseNumber": '',
                      "processingLab": '',
                      "analysisLab": '',
                      "professionalLab": '',
                      "customData": '{}',
                      "panels": [
                        {
                            "panelName": '',
                            "customData": '{}'
                        }
                      ],
                      "tests": [
                        {
                            "testName": '',
                            "customData": '{}'
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
                }],
            patients: [
                  {
                      "id": 0,
                      "lastName": '',
                      "firstName": '',
                      "dob": '01/01/1900',
                      "ssn": '000-00-000'
                  }
            ],
        }
    };