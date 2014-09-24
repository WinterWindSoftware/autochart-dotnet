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
                    description: 'Client library for fetching data from AutoChart REST API',
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
            dist: {
                files: [{
                    expand: true,
                    src: 'v3.5/AutoChart.Sdk/bin/Release/*.dll',
                    dest: 'v3.5/dist',
                    flatten: true,
                    filter: 'isFile'
                }]
            }

        }
    });

    // TASKS
    grunt.registerTask('build', ['assemblyinfo', 'msbuild', 'copy']);
    grunt.registerTask('default', ['build']);

};