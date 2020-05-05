db.user.insertMany([
    {
        "login": "smet_k",
        "password": "password_hash",
        "name": {
            "firstname": "f",
            "lastname": "l",
            "middlename": "m"
        },
        "avatar": "/static/default.png",
        "karma": 0,
        "registered": Date(),
        "languages": [
            "english",
            "russian"
        ]
    },
    {
        "login": "smet_k_1",
        "password": "password_hash",
        "name": {
            "firstname": "f_1",
            "lastname": "l_2",
            "middlename": "m_3"
        },
        "avatar": "/static/new.png",
        "karma": 1,
        "registered": Date(),
        "languages": [
            "english",
            "russian",
            "prussian"
        ]
    }
]);

db.post.insertMany([
    {
        "header": "new post header",
        "short_topic": "post short topic",
        "main_topic": "very interesting topic ",
        "user": new DBRef("user", ObjectId("5eb04beee244723e67ab5387"), "pbd"),
        "show": false,
        "created": Date(),
    },
    {
        "header": "another new post header",
        "short_topic": "another post short topic",
        "main_topic": "another very interesting topic ",
        "user": new DBRef("user", ObjectId("5eb04beee244723e67ab5387"), "pbd"),
        "show": true,
        "created": Date(),
    },
]);