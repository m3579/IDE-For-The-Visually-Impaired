from django.conf.urls import url

from . import views

urlpatterns = [
	url(r"^symbolmap", views.symbolmap, name="symbolmap")
]
