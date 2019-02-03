var gulp = require("gulp"),
  less = require("gulp-less");

gulp.task("less", function () {
  return gulp.src('*.less')
    .pipe(less())
    .pipe(gulp.dest('.'));
});

gulp.task('default', gulp.task('less'));