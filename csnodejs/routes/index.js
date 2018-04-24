var express = require('express');
var router = express.Router();

router.get('/', function(req, res, next) {
  res.render('index', { title: 'PCF Configuration Server Demo', appConfig: global.AppConfig });
});

module.exports = router;