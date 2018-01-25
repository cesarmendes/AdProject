/// <binding BeforeBuild='move:vue' AfterBuild='move:vue' />
"use strict";

var gulp = require("gulp"),
    gulpu = require("gulp-util"),
    concat = require("gulp-concat"),
    cssmin = require("gulp-cssmin"),
    htmlmin = require("gulp-htmlmin"),
    uglify = require("gulp-uglify"),
    merge = require("merge-stream"),
    del = require("del"),
    bundleconfig = require("./bundleconfig.json");

var regex = {
    css: /\.css$/,
    html: /\.(html|htm)$/,
    js: /\.js$/
};

var path = {
    node: 'node_modules',
    libs: 'wwwroot/lib'
};

var pathMove = [
    path.node + "/animate.css/**/*",
    path.node + "/bootstrap/**/*",
    path.node + "/icheck/**/*",
    path.node + "/font-awesome/**/*",
    path.node + "/jquery/**/*",
    path.node + "/jquery-validation/**/*",
    path.node + "/jquery-validation-unobtrusive/**/*",
    path.node + "/popper.js/**/*",
    path.node + "/sweetalert2/**/*",
    path.node + "/vue/**/*",
    path.node + "/vue-resource/**/*"
];


gulp.task("min", ["min:js", "min:css", "min:html"]);

gulp.task("min:js", function () {
    var tasks = getBundles(regex.js).map(function (bundle) {
        return gulp.src(bundle.inputFiles)
            .pipe(concat(bundle.outputFileName))
            .pipe(uglify())
            .pipe(gulp.dest("."));
    });
    return merge(tasks);
});

gulp.task("min:css", function () {
    var tasks = getBundles(regex.css).map(function (bundle) {
        return gulp.src(bundle.inputFiles, { base: "." })
            .pipe(concat(bundle.outputFileName))
            .pipe(cssmin())
            .pipe(gulp.dest("."));
    });
    return merge(tasks);
});

gulp.task("min:html", function () {
    var tasks = getBundles(regex.html).map(function (bundle) {
        return gulp.src(bundle.inputFiles, { base: "." })
            .pipe(concat(bundle.outputFileName))
            .pipe(htmlmin({ collapseWhitespace: true, minifyCSS: true, minifyJS: true }))
            .pipe(gulp.dest("."));
    });
    return merge(tasks);
});

gulp.task("clean", function () {
    var files = bundleconfig.map(function (bundle) {
        return bundle.outputFileName;
    });

    return del(files);
});

gulp.task("watch", function () {
    getBundles(regex.js).forEach(function (bundle) {
        gulp.watch(bundle.inputFiles, ["min:js"]);
    });

    getBundles(regex.css).forEach(function (bundle) {
        gulp.watch(bundle.inputFiles, ["min:css"]);
    });

    getBundles(regex.html).forEach(function (bundle) {
        gulp.watch(bundle.inputFiles, ["min:html"]);
    });
});

//Move VueJs para libs
gulp.task('move:packages', function () {
    gulp.src(pathMove, { base: path.node })
        .pipe(gulp.dest(path.libs));
});

function getBundles(regexPattern) {
    return bundleconfig.filter(function (bundle) {
        return regexPattern.test(bundle.outputFileName);
    });
}

gulp.task('logs', function ()
{
    gulpu.log(path);
    gulpu.log(pathMove);
});
