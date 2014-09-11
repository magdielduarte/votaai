var gulp  = require('gulp'),
minifyCSS = require('gulp-minify-css'),
imagemin  = require('gulp-imagemin'),
concat    = require('gulp-concat'),
rename    = require('gulp-rename'),
sass      = require('gulp-sass'),
uglify    = require('gulp-uglify'),
jade      = require('gulp-jade');



var pathsDev = {
  jade: ['./dev/*.jade'],
  JadeWatch: ['./dev/*.jade', './dev/includes_jade/*.jade'],
  styles: ['./dev/assets/scss/*.scss'],
  scripts: ['./dev/assets/js/*.js'],
  image: ['./dev/assets/img/*.*']

};


var pathsBuild = {
  styles: ['./build/assets/css/*.css']
};


// Task for concat and minfier  and convert sass to css files 
gulp.task('concat-min-sass-css', function() {
  gulp.src(pathsDev.styles)
    .pipe(sass())
    .pipe(concat('main.css'))
    .pipe(minifyCSS(opts))
    .pipe(rename({suffix: '.min'}))
    .pipe(gulp.dest('./build/assets/css/'));
});


// Task for minifier the images
gulp.task('imagemin',function () {
  gulp.src(pathsDev.image)
    .pipe(imagemin())
    .pipe(gulp.dest('./build/assets/img/'));
})


// Task for concat and minifier the *.js files
gulp.task('concat-min-js', function() {
  gulp.src(pathsDev.scripts)
    .pipe(concat('main.js'))
      .pipe(uglify())
      .pipe(rename({suffix: '.min'}))
      .pipe(gulp.dest('./build/assets/js/'));
});

//task for compile jada for html
gulp.task('jade', function() {
  gulp.src(pathsDev.jade)
    .pipe(jade({pretty: true}))
    .pipe(gulp.dest('./build/'))
});


gulp.task('watch',function(){
    gulp.watch(pathsDev.scripts, ['concat-min-js']);
    gulp.watch(pathsDev.JadeWatch, ['jade']);
    gulp.watch(pathsDev.styles, ['concat-min-sass-css']);
});


// Taks default gulp! 
gulp.task('default', ['imagemin', 'jade', 'concat-min-sass-css', 'concat-min-js', 'watch'], function(){ });





