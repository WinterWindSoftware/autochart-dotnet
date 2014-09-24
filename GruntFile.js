module.exports = function(grunt) {
    require('load-grunt-tasks')(grunt);

    grunt.file.setBase(__dirname);

    // Project configuration.
    grunt.initConfig({
        pkg: grunt.file.readJSON('package.json'),
        assemblyinfo: {
            options: {
                files: ['v3.5/AutoChart.Sdk/Properties/AssemblyInfo.cs'],
                info: {
                    title: 'AutoChart.Sdk',
                    description: '<%=pkg.description%>',
                    configuration: 'Release',
                    company: 'Winter Wind Software Ltd',
                    product: 'AutoChart',
                    copyright: 'Copyright 2014 Winter Wind Software Ltd',
                    version: '<%=pkg.version%>',
                    fileVersion: '<%=pkg.version%>'
                }
            }
        },
        msbuild: {
            dist: {
                src: ['v3.5/AutoChart.Sdk/AutoChart.Sdk.csproj'],
                options: {
                    projectConfiguration: 'Release',
                    targets: ['Clean', 'Rebuild'],
                    stdout: true,
                    version: 4.0,
                    maxCpuCount: 4,
                    buildParameters: {
                        WarningLevel: 2
                    },
                    verbosity: 'quiet'
                }
            }
        },
        copy: {
            assemblyinfo: {
                files: [{
                    expand: true,
                    cwd: 'v3.5/AutoChart.Sdk/Properties',
                    src: 'AssemblyInfo.cs.sample',
                    dest: 'v3.5/AutoChart.Sdk/Properties/',
                    rename: function(dest, src) {
                        return dest + src.replace('.sample', '');
                    }
                }]
            },
            dist: {
                files: [{
                    expand: true,
                    src: 'v3.5/AutoChart.Sdk/bin/Release/*.dll',
                    dest: 'v3.5/dist',
                    flatten: true,
                    filter: 'isFile'
                }]
            }
        },
        nugetpack: {
            dist: {
                src: 'v3.5/AutoChart.Sdk/AutoChart.Sdk.csproj',
                dest: 'dist/',
                options: {
                    version: '<%=pkg.version%>'
                }
            }
        },
        nugetpush: {
            dist: {
                src: 'dist/*.nupkg',

                options: {
                    apiKey: process.env['NUGET_API_KEY']
                }
            }
        }
    });

    // TASKS
    grunt.registerTask('build', ['copy:assemblyinfo', 'assemblyinfo', 'msbuild']);
    grunt.registerTask('dist', ['build', 'nugetpack']);
    grunt.registerTask('default', ['build']);

};