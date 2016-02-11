/// <binding Clean='clean' />
"use strict";

var gulp = require("gulp"),
  rimraf = require("rimraf"),
  concat = require("gulp-concat"),
  cssmin = require("gulp-cssmin"),
  uglify = require("gulp-uglify"),
  _ = require("lodash");

var webroot = "./wwwroot/";
var include = {
  js: [
    './node_modules/bootstrap/dist/js/bootstrap.js',
    './node_modules/systemjs/dist/system.js',
    './node_modules/systemjs/dist/system-polyfills.js',
    './node_modules/rxjs/bundles/Rx.js',
    './node_modules/typescript/lib/typescript.js',
    './node_modules/jquery/dist/jquery.js',
    './node_modules/es6-shim/es6-shim.min.js',
  ],
  angularJs: [
    './node_modules/angular2/bundles/angular2.dev.js',
    './node_modules/angular2/bundles/router.dev.js',
    './node_modules/angular2/bundles/angular2-polyfills.js',
    './node_modules/angular2/bundles/http.dev.js'
  ]
};

var dist = {
  lib: webroot + '/lib'
};

var paths = {
  js: webroot + "js/**/*.js",
  minJs: webroot + "js/**/*.min.js",
  css: webroot + "css/**/*.css",
  minCss: webroot + "css/**/*.min.css",
  concatJsDest: webroot + "js/site.min.js",
  concatCssDest: webroot + "css/site.min.css"
};

gulp.task("clean:js", function (cb) {
  rimraf(paths.concatJsDest, cb);
});

gulp.task("clean:css", function (cb) {
  rimraf(paths.concatCssDest, cb);
});

gulp.task("clean", ["clean:js", "clean:css"]);

gulp.task("min:angularjs", function () {
  _.forEach(include.angularJs, function (file) {
    gulp.src(file)
      .pipe(gulp.dest(dist.lib));
  });
});

gulp.task("min:devjs", function () {
  _.forEach(include.js, function (file) {
    gulp.src(file)
      .pipe(gulp.dest(dist.lib));
  })
});

gulp.task("min:sourcejs", function () {
  return gulp.src([paths.js, "!" + paths.minJs], {
    base: "."
  })
    .pipe(concat(paths.concatJsDest))
    .pipe(uglify())
    .pipe(gulp.dest("."));
})

gulp.task("min:js", ['min:devjs', 'min:angularjs', 'min:sourcejs']);

gulp.task("min:css", function () {
  return gulp.src([paths.css, "!" + paths.minCss])
    .pipe(concat(paths.concatCssDest))
    .pipe(cssmin())
    .pipe(gulp.dest("."));
});

gulp.task("min", ["min:js", "min:css"]);
