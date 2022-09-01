from django import forms
from django.contrib.auth.forms import UserCreationForm
from django.contrib.auth.models import User

from gradebook.models import Semester, Course, Class, Student, Lecturer, StudentEnrollment


class CreateSemesterForm(forms.ModelForm):
    class Meta:
        model = Semester
        fields = ('year', 'semester')
        widgets = {
            'year': forms.NumberInput(attrs={'class': 'form-control'}),
            'semester': forms.TextInput(attrs={'class': 'form-control'}),
        }


class UpdateSemesterForm(forms.ModelForm):
    class Meta:
        model = Semester
        fields = ('year', 'semester')
        widgets = {
            'year': forms.NumberInput(attrs={'class': 'form-control'}),
            'semester': forms.TextInput(attrs={'class': 'form-control'}),
        }


class CreateCourseForm(forms.ModelForm):
    class Meta:
        model = Course
        fields = ('code', 'name')
        widgets = {
            'code': forms.TextInput(attrs={'class': 'form-control'}),
            'name': forms.TextInput(attrs={'class': 'form-control'}),
        }


class UpdateCourseForm(forms.ModelForm):
    class Meta:
        model = Course
        fields = ('code', 'name')
        widgets = {
            'code': forms.TextInput(attrs={'class': 'form-control'}),
            'name': forms.TextInput(attrs={'class': 'form-control'}),
        }


class CreateClassForm(forms.ModelForm):
    class Meta:
        model = Class
        fields = ('number', 'course', 'semester', 'lecturer')
        widgets = {
            'number': forms.NumberInput(attrs={'class': 'form-control'}),
            'course': forms.Select(attrs={'class': 'form-control'}),
            'semester': forms.Select(attrs={'class': 'form-control'}),
            'lecturer': forms.Select(attrs={'class': 'form-control'}),
        }


class UpdateClassForm(forms.ModelForm):
    class Meta:
        model = Class
        fields = ('number', 'course', 'semester', 'lecturer')
        widgets = {
            'number': forms.NumberInput(attrs={'class': 'form-control'}),
            'course': forms.Select(attrs={'class': 'form-control'}),
            'semester': forms.Select(attrs={'class': 'form-control'}),
            'lecturer': forms.Select(attrs={'class': 'form-control'}),
        }


class CreateLecturerClassAssignmentForm(forms.ModelForm):
    class Meta:
        model = Class
        fields = ('number', 'semester', 'course', 'lecturer')
        widgets = {
            'number': forms.NumberInput(attrs={'class': 'form-control'}),
            'semester': forms.Select(attrs={'class': 'form-control'}),
            'course': forms.Select(attrs={'class': 'form-control'}),
            'lecturer': forms.Select(attrs={'class': 'form-control'}),
        }




class CreateLecturerForm(forms.ModelForm):
    class Meta:
        model = Lecturer
        fields = ('firstname', 'lastname', 'email', 'DOB', 'course')
        widgets = {
            'firstname': forms.TextInput(attrs={'class': 'form-control'}),
            'lastname': forms.TextInput(attrs={'class': 'form-control'}),
            'email': forms.EmailInput(attrs={'class': 'form-control'}),
            'DOB': forms.DateInput(attrs={'class': 'form-control'}),
            'course': forms.CheckboxSelectMultiple(attrs={'class': 'form-control'}),
        }


class UpdateLecturerForm(forms.ModelForm):
    class Meta:
        model = Lecturer
        fields = ('firstname', 'lastname', 'email', 'DOB', 'course')
        widgets = {
            'firstname': forms.TextInput(attrs={'class': 'form-control'}),
            'lastname': forms.TextInput(attrs={'class': 'form-control'}),
            'email': forms.EmailInput(attrs={'class': 'form-control'}),
            'DOB': forms.DateInput(attrs={'class': 'form-control'}),
            'course': forms.CheckboxSelectMultiple(attrs={'class': 'form-control'}),
        }


class CreateStudentForm(forms.ModelForm):
    class Meta:
        model = Student
        fields = ('firstname', 'lastname', 'email', 'DOB')
        widgets = {
            'firstname': forms.TextInput(attrs={'class': 'form-control'}),
            'lastname': forms.TextInput(attrs={'class': 'form-control'}),
            'email': forms.EmailInput(attrs={'class': 'form-control'}),
            'DOB': forms.DateInput(attrs={'class': 'form-control'}),
        }


class UpdateStudentForm(forms.ModelForm):
    class Meta:
        model = Student
        fields = ('firstname', 'lastname', 'email', 'DOB')
        widgets = {
            'firstname': forms.TextInput(attrs={'class': 'form-control'}),
            'lastname': forms.TextInput(attrs={'class': 'form-control'}),
            'email': forms.EmailInput(attrs={'class': 'form-control'}),
            'DOB': forms.DateInput(attrs={'class': 'form-control'}),
        }


class CreateStudentEnrollmentForm(forms.ModelForm):
    class Meta:
        model = StudentEnrollment
        fields = ('studentID', 'classID')
        widgets = {
            'studentID': forms.Select(attrs={'class': 'form-control'}),
            'classID': forms.Select(attrs={'class': 'form-control'}),
        }


class AddGradeForm(forms.ModelForm):
    class Meta:
        model = StudentEnrollment
        fields = ('studentID', 'classID', 'grade')
        widgets = {
            'studentID': forms.Select(attrs={'class': 'form-control'}),
            'classID': forms.Select(attrs={'class': 'form-control'}),
            'grade': forms.TextInput(attrs={'class': 'form-control'}),
        }


