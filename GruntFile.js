module.exports = function(grunt) {

    grunt.file.setBase(__dirname);
    console.log("__dirname = " + __dirname);

  // Project configuration.
    grunt.initConfig({
        pkg: grunt.file.readJSON('package.json'),
        msbuild: {
            dist: {
                src: ['dotnet/AutoChart.Sdk.sln'],
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
        }        
    });

    //Load 3rd party tasks
    grunt.loadNpmTasks('grunt-msbuild');

    //Custom Tasks
    grunt.registerTask('keensync', 'Keen Data Sync', function() {
        var done = this.async();
        var KeenSyncRunner = require('./' + keenWebJobDir + '/KeenSyncRunner');
        new KeenSyncRunner().run(done);
    } );

    // TASKS
    grunt.registerTask('build', ['msbuild']);
    grunt.registerTask('default', ['build']);

};