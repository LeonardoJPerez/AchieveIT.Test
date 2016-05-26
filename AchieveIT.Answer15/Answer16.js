// References:
// https://nodejs.org/api/fs.html#fs_fs_readfile_file_options_callback
// https://nodejs.org/api/readline.html#readline_example_read_file_stream_line_by_line

var readline = require('readline');
var fs = require("fs");

if (process.argv.length < 4) {
    console.log("No argumets specified.");
    console.log("Enter [Filename with path] [Line number] as arguments to this application.");

    return;
}

var file = process.argv[2];
var lineNumber = process.argv[3];

var reader = readline.createInterface({
    input: fs.createReadStream(file, { encoding: 'utf8' })
});

var i = 0;
var exit = false;
reader.on('line', function (line) {
    if (i++ == lineNumber) {
        console.log('[Line: #' + lineNumber + '] - ' + '"' + line + '"');
        exit = true;
    }

    if (exit) { return; }
});