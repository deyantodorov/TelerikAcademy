module.exports = function(grunt) {
    grunt.initConfig({
        project: {
            app: 'app'
        },
        connect: {
            options: {
                port: 9578,
                livereload: 35729,
                hostname: 'localhost'
            },
            livereload: {
                options: {
                    open: true,
                    base: [
                        'dev'
                    ]
                }
            }
        },
        watch: {
            js: {
                files: ['Gruntfile.js', 'dev/scripts/*.js'],
                tasks: ['jshint'],
                options: {
                    livereload: true
                }
            },
            coffee: {
                files: ['<%= project.app %>/**/*.coffee'],
                tasks: ['coffee'],
                options: {
                    livereload: true
                }
            },
            styles: {
                files: ['<%= project.app %>/**/*.styl'],
                tasks: ['stylus'],
                options: {
                    livereload: true
                }
            },
            jade: {
                files: ['<%= project.app %>/**/*.jade'],
                tasks: ['jade'],
                options: {
                    livereload: true
                }
            },
            html: {
                files: ['dev/**/*.html'],
                options: {
                    livereload: true
                }
            },
            livereload: {
                options: {
                    livereload: '<%= connect.options.livereload %>'
                },
                files: [
                    'dev/*.html',
                    'dev/scripts/*.js',
                    'dev/styles/*.css'
                ]
            }
        },
        coffee: {
            compile: {
                options: {
                    bare: true
                },
                files: {
                    'dev/scripts/scripts.js': 'app/scripts.coffee'
                }
            }
        },
        jshint: {
            all: ['Gruntfile.js', 'dev/scripts/**/*.js']
        },
        stylus: {
            compile: {
                options: {
                    compress: false
                },
                files: {
                    'dev/styles/styles.css': 'app/styles.styl'
                }
            }
        },
        jade: {
            compile: {
                options: {
                    pretty: true
                },
                files: {
                    'dev/index.html': 'app/index.jade'
                }
            }
        },
        copy: {
            main: {
                files: [{
                    expand: true,
                    cwd: 'app/images',
                    src: '**/*',
                    dest: 'dev/images'
                }, {
                    expand: true,
                    cwd: 'app/images',
                    src: '**/*',
                    dest: 'dist/images'
                }]
            }
        },
        csslint: {
            app: ['dev/styles/*.css']
        },
        concat: {
            js: {
                files: {
                    'dist/scripts/build.js': ['dev/scripts/**/*.js']
                }
            },
            css: {
                files: {
                    'dist/styles/build.css': ['dev/styles/**/*.css']
                }
            }
        },
        uglify: {
            js: {
                files: {
                    'dist/scripts/build.min.js': 'dist/scripts/build.js'
                }
            }
        },
        cssmin: {
            css: {
                files: {
                    'dist/styles/build.min.css': 'dist/styles/build.css'
                }
            }
        },
        htmlmin: {
            dist: {
                options: {
                    removeComments: true,
                    collapseWhitespace: true
                },
                files: {
                    'dist/index.html': 'dev/index.html'
                }
            }
        }
    });

    grunt.loadNpmTasks('grunt-contrib-coffee');
    grunt.loadNpmTasks('grunt-contrib-jshint');
    grunt.loadNpmTasks('grunt-contrib-stylus');
    grunt.loadNpmTasks('grunt-contrib-jade');
    grunt.loadNpmTasks('grunt-contrib-copy');
    grunt.loadNpmTasks('grunt-contrib-connect');
    grunt.loadNpmTasks('grunt-contrib-watch');
    grunt.loadNpmTasks('grunt-contrib-csslint');
    grunt.loadNpmTasks('grunt-contrib-concat');
    grunt.loadNpmTasks('grunt-contrib-uglify');
    grunt.loadNpmTasks('grunt-contrib-cssmin');
    grunt.loadNpmTasks('grunt-contrib-htmlmin');

    grunt.registerTask('serve', [
        'coffee',
        'jshint',
        'stylus',
        'jade',
        'copy',
        'connect',
        'watch'
    ]);

    grunt.registerTask('build', [
        'coffee',
        'jshint',
        'stylus',
        'jade',
        'csslint',
        'concat',
        'uglify',
        'cssmin',
        'htmlmin',
        'copy'
    ]);
};