from django.http import HttpResponse 
from django.shortcuts import render

import json


def index(request):
    return render(request, "KeyboardCodeIDE/index.html", {})


def symbolmap(request):
    # TODO: these need to be language-dependent
    # TODO: these names may need to be shortened
    # TODO: make a clearer distinction between braces ({}) and brackets([])
    testing_symbolmap = {
        # TODO: maybe add an entry for "enter" ("\n")?
    }
    
    testing_symbolmap_json = json.dumps(testing_symbolmap)
    return HttpResponse(testing_symbolmap_json)	
