from django.http import HttpResponse 
from django.shortcuts import render

import json


def index(request):
    return render(request, "KeyboardCodeIDE/index.html", {})


def symbolmap(request):
    # TODO: these names may need to be shortened
    # TODO: make a clearer distinction between braces ({}) and brackets([])
    testing_symbolmap = {
            "^": "caret",
            "(": "left parenthesis",
            ")": "right parenthesis",
            "-": "dash",
            "_": "underscore",
            "[": "open bracket",
            "]": "close bracket",
            "{": "open brace",
            "}": "close brace",
            "|": "vertical bar",
            ";": "semicolon",
            "\"": "double quote",
            "'": "single quote",
            "<": "less than",
            ">": "greater than",
            ",": "com ma",  # It is "com ma" because meSpeak.js just says "com" for "comma"
            ".": "period",   # TODO: maybe change this to "dot" based on language?
            "?": "question mark",
            "`": "backtick"
            # TODO: maybe add an entry for "enter" ("\n")?
        }
    
    testing_symbolmap_json = json.dumps(testing_symbolmap)
    return HttpResponse(testing_symbolmap_json)	
