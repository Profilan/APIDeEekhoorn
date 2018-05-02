define({ "api": [
  {
    "success": {
      "fields": {
        "Success 200": [
          {
            "group": "Success 200",
            "optional": false,
            "field": "varname1",
            "description": "<p>No type.</p>"
          },
          {
            "group": "Success 200",
            "type": "String",
            "optional": false,
            "field": "varname2",
            "description": "<p>With type.</p>"
          }
        ]
      }
    },
    "type": "",
    "url": "",
    "version": "0.0.0",
    "filename": "./doc/main.js",
    "group": "C__Users_raymond_source_repos_APIDeEekhoorn_APIDeEekhoorn_doc_main_js",
    "groupTitle": "C__Users_raymond_source_repos_APIDeEekhoorn_APIDeEekhoorn_doc_main_js",
    "name": ""
  },
  {
    "type": "get",
    "url": "/api/dashboard",
    "title": "Request Dashboard information",
    "version": "1.0.0",
    "name": "GetDashboard",
    "group": "Dashboard",
    "header": {
      "fields": {
        "Header": [
          {
            "group": "Header",
            "type": "String",
            "optional": false,
            "field": "Authorization",
            "description": "<p>Basic Authorization value (provided by De Eekhoorn Woodworkings B.V.)</p>"
          }
        ]
      }
    },
    "parameter": {
      "fields": {
        "Parameter": [
          {
            "group": "Parameter",
            "type": "String",
            "optional": false,
            "field": "debcode",
            "description": "<p>Debtor Code</p>"
          },
          {
            "group": "Parameter",
            "type": "String",
            "optional": false,
            "field": "apikey",
            "description": "<p>Unique key for the user</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Request-Example:",
          "content": "/api/dashboard?debcode=000504&apikey=fftt2sQjjaiSXnX2Qnvr3XnahdDB3ZRDLTnRtpJr",
          "type": "json"
        }
      ]
    },
    "success": {
      "examples": [
        {
          "title": "Success-Response:",
          "content": "HTTP/1.1. 200 OK\n{\n    \"Quantity\": {\n        \"Year\": {\n            \"Items\": [\n                {\n                    \"EAN\": \"8714713056163\",\n                    \"Amount\": 993\n                },\n                {\n                    \"EAN\": \"8714713057887\",\n                    \"Amount\": 875\n                },\n                ...\n            ],\n        \"Quarter\":\n            \"Items\": [\n                {\n                    \"EAN\": \"8714713056163\",\n                    \"Amount\": 993\n                },\n                {\n                    \"EAN\": \"8714713057887\",\n                    \"Amount\": 875\n                },\n                ...\n            ],\n        \"Month\":\n            \"Items\": [\n                {\n                    \"EAN\": \"8714713056163\",\n                    \"Amount\": 993\n                },\n                {\n                    \"EAN\": \"8714713057887\",\n                    \"Amount\": 875\n                },\n                ...\n            ]\n    },\n    \"Sales\": {\n        \"Year\": {\n            \"Items\": [\n                {\n                    \"EAN\": \"8714713056163\",\n                    \"Amount\": 993\n                },\n                {\n                    \"EAN\": \"8714713057887\",\n                    \"Amount\": 875\n                },\n                ...\n            ],\n        \"Quarter\":\n            \"Items\": [\n                {\n                    \"EAN\": \"8714713056163\",\n                    \"Amount\": 993\n                },\n                {\n                    \"EAN\": \"8714713057887\",\n                    \"Amount\": 875\n                },\n                ...\n            ],\n        \"Month\":\n            \"Items\": [\n                {\n                    \"EAN\": \"8714713056163\",\n                    \"Amount\": 993\n                },\n                {\n                    \"EAN\": \"8714713057887\",\n                    \"Amount\": 875\n                },\n                ...\n            ]\n        }\n    }\n}",
          "type": "json"
        }
      ]
    },
    "error": {
      "fields": {
        "Error 4xx": [
          {
            "group": "Error 4xx",
            "type": "401",
            "optional": false,
            "field": "NotAuthorized",
            "description": "<p>The user is not authorized.</p>"
          }
        ]
      }
    },
    "filename": "./Controllers/DashboardController.cs",
    "groupTitle": "Dashboard"
  }
] });
