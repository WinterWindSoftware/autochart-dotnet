module.exports = function(grunt) {

    grunt.file.setBase(__dirname);
    console.log("__dirname = " + __dirname);

  // Project configuration.
    grunt.initConfig({
        pkg: grunt.file.readJSON('package.json'),
        msbuild: {
            dist: {
                src: ['dotnet/AutoChart.Sdk/AutoChart.Sdk.csproj'],
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
                    src: 'dotnet/AutoChart.Sdk/bin/Release/*.dll',
                    dest: 'dotnet/dist',
                    flatten: true,
                    filter: 'isFile'
                }
                ]
            }
            
        } 
    });

    //Load 3rd party tasks
    grunt.loadNpmTasks('grunt-msbuild');
    grunt.loadNpmTasks('grunt-contrib-copy');

    // TASKS
    grunt.registerTask('build', ['msbuild', 'copy']);
    grunt.registerTask('default', ['build']);

};