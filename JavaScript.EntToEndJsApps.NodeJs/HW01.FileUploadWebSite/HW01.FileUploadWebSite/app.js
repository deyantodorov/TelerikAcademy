var http = require('http'),
	util = require('util'),
	fs = require('fs-extra'),
	url = require('url'),
	guid = require('guid'),
	formidable = require('formidable');

var UPLOAD_DIR = 'uploads/',
	PORT = 1234;

var filesCache = [];
var imgs = '';
var isFileRead = 0;

// HTML elements used for response
var css = '#wrap form span,#wrap h1{text-transform:uppercase}#wrap{width:800px;margin:0 auto;padding:50px;background:grey;border-radius:5px}#wrap form{margin:10px 20px 20px}#wrap form input{display:block;margin:20px;cursor:pointer;font-size:1.2em}#wrap form input[type=file]{background:#b6ff00}#wrap form span{display:inline-block;margin:0 0 0 20px;padding:10px;border-radius:5px;background:#ff6a00;border:3px solid #000;cursor:pointer}#wrap h1{color:#0ff;text-align:center}#wrap h2 {text-align: center;}#wrap h2 a {color: #ff6a00;text-align: center;text-transform: uppercase;}#wrap h3 {color: #0ff;text-transform: uppercase;}';
var js = 'function submit(){var e=document.getElementById("file"),t=document.getElementById("form");""!==e.value?t.submit():alert("Please, choose some file!")}';
var header = '<!DOCTYPE html><html xmlns="http://www.w3.org/1999/xhtml">' +
    '<head>' +
    '<meta charset="utf-8"/>' +
    '<title>File Upload WebSite</title>' +
    '<style type="text/css">' +
	css +
    '</style>' +
    '</head>' +
    '<body>' +
    '<div id="wrap">';
var content = '';
var footer = '</div>' +
			 '<script type="text/javascript">' +
			 js +
			 '</script>' +
			 '</body></html>';

function showIndex(req, res) {
	res.writeHead(200, {
		'Content-Type': 'text/html'
	});
	
	content = '<h1>Upload file</h1>' +
			  '<form method = "post" action = "/upload" id = "form" enctype="multipart/form-data">' +
			  '<input type="file" name="file" id="file"/>' +
			  '<span onclick="submit()">Upload File</span>' +
			  '</form>';

    //console.log(isFileRead);

	if (isFileRead === 0) {
		filesCache = fs.readdirSync(UPLOAD_DIR);
	    isFileRead = 1;
	}
	
	imgs = '<div id="imgs"><h3>Files: </h3>';

    //console.log(filesCache);

	if (filesCache.length > 0) {
		var index, 
			length = filesCache.length;

		for (index = 0; index < length; index++) {
			var img = '<p><a href="' + '/uploads/' + filesCache[index] + '" target="_blank">File ' + index + '</a>' + '</p>';
			imgs += img;
		}
	}
	
	imgs += '</div>';
	
	content += imgs;
	res.write(header + content + footer);
	res.end();
}

// Load success
function showSuccess(req, res) {
	res.writeHead(200, {
		'Content-Type': 'text/html'
	});
	
	content = '<h1>File uploaded successfuly. See Uploads directory on this project.</h1>' +
			  '<h2><a href="/">Upload new file or wait 3 seconds for redirect</a></h2>' +
			  '<script type="text/javascript">window.setTimeout(function() {location.href = "/";}, 3000);</script>';
	
	res.write(header + content + footer);
	res.end();
}

// Show error message
function showError(req, res) {
	res.writeHead(200, {
		'Content-Type': 'text/html'
	});
	
	content = '<h1>Error while uploading your file</h1>';
	
	res.write(header + content + footer);
	res.end();
}

function getFileExtension(fileName) {
	fileName = fileName + '';
	
	var startIndex = fileName.indexOf('.');
	var endIndex = fileName.length;
	var extension = fileName.substring(startIndex, endIndex);
	
	return extension;
}

// Manage upload functionality
function uploadFile(req, res) {
	if (req.method.toLowerCase() !== 'post') {
		showError(req, res);
	} else {
		var form = new formidable.IncomingForm();
		
		form.parse(req, function (err) {
			if (err) {
				console.log(err);
			} else {
				showSuccess(req, res);
			}
		});
		
		form.on('progress', function (bytesReceived, bytesExpected) {
			var percentComplete = (bytesReceived / bytesExpected) * 100;
			console.log(percentComplete.toFixed(2));
		});
		
		form.on('error', function (err) {
			console.log(err);
		});
		
		form.on('end', function () {
			var tempPath = this.openedFiles[0].path;
			var fileName = guid.create();
			var fileExtension = getFileExtension(this.openedFiles[0].name);
			
			fs.move(tempPath, UPLOAD_DIR + fileName + fileExtension, function (err) {
				if (err) {
					console.log(err);
				} else {
					console.log('Success!');
				}
			});
		});
	}
}

// Run server
var server = http.createServer(function (req, res) {
	var parsedUrl = url.parse(req.url).pathname;
	//console.log(parsedUrl);
	
	// Routing
	switch (parsedUrl) {
		case '/upload':
			uploadFile(req, res);
			isFileRead = 0; // reset file cache
			break;
		case '/':
			showIndex(req, res);
			break;
		case '/favicon.ico':
			res.writeHead(404, { 'Content-Type': 'image/x-icon' });
			res.end();
			isFileRead = 0; // reset file cache
			break;
		default:
			if (parsedUrl.indexOf('uploads/') > 0) {
				fs.readFile(parsedUrl.substring(1, parsedUrl.length), function (err, data) {
					if (err) {
						console.log(err);
					} else {
						res.write(data);
					}
					
					res.end();
				});
			} else {
				res.end();
			}
			isFileRead = 0; // reset file cache
			break;
	}
});

server.listen(PORT);
console.log('Server is runnning on http://localhost:' + PORT);