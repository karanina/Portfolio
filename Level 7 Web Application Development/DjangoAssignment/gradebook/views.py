from django.contrib.auth.models import User, Group
from django.core.exceptions import ObjectDoesNotExist
from django.core.files.storage import FileSystemStorage,default_storage
from django.core.mail import send_mail
from django.shortcuts import render, redirect, get_object_or_404
from django.http import HttpResponse
from django.urls import reverse_lazy
from django.views.generic import CreateView, ListView, DetailView, UpdateView, DeleteView
from gradebook.forms import CreateSemesterForm, UpdateSemesterForm, CreateCourseForm, UpdateCourseForm, \
    CreateClassForm, UpdateClassForm

from gradebook.models import Semester, Course, Class, Student, Lecturer, StudentEnrollment
import pyrebase

config = {
  'apiKey': "AIzaSyCgHtFhWXBicwRfi68f526vmURvwBImejs",
  'authDomain': "iscg7420-gradebook.firebaseapp.com",
  'projectId': "iscg7420-gradebook",
  'storageBucket': "iscg7420-gradebook.appspot.com",
  'messagingSenderId': "833413915587",
  'appId': "1:833413915587:web:9a26a7660b80dc973c5376",
  'measurementId': "G-VGLFXZWRCZ",
  'databaseURL':""
}

firebase = pyrebase.initialize_app(config)
storage = firebase.storage()


def index(request):
    context = {'title': 'Gradebook Home', 'content': 'Welcome to The Grade Book'}
    return render(request, 'index.html', context)


class ListSemester(ListView):
    model = Semester
    template_name = 'Semester Management/list_semester.html'
    ordering = ['year']


class SemesterDetail(DetailView):
    model = Semester
    template_name = 'Semester Management/semester_detail.html'


class CreateSemester(CreateView):
    model = Semester
    form_class = CreateSemesterForm
    template_name = "Semester Management/create_semester.html"
    success_url = reverse_lazy("list_semester")


class UpdateSemester(UpdateView):
    model = Semester
    form_class = UpdateSemesterForm
    template_name = "Semester Management/update_semester.html"
    success_url = reverse_lazy("list_semester")


class DeleteSemester(DeleteView):
    model = Semester
    template_name = "Semester Management/delete_semester.html"
    success_url = reverse_lazy("list_semester")


class ListCourse(ListView):
    model = Course
    template_name = 'Course_Management/list_course.html'
    ordering = ['code']


class CourseDetail(DetailView):
    model = Course
    template_name = 'Course_Management/course_detail.html'


class CreateCourse(CreateView):
    model = Course
    form_class = CreateCourseForm
    template_name = "Course_Management/create_course.html"
    success_url = reverse_lazy("list_course")


class UpdateCourse(UpdateView):
    model = Course
    form_class = UpdateCourseForm
    template_name = "Course_Management/update_course.html"
    success_url = reverse_lazy("list_course")


class DeleteCourse(DeleteView):
    model = Course
    template_name = "Course_Management/delete_course.html"
    success_url = reverse_lazy("list_course")


class ListClass(ListView):
    model = Class
    template_name = 'Class_Management/list_class.html'
    ordering = ['number']


class ClassDetail(DetailView):
    model = Class
    template_name = 'Class_Management/class_detail.html'


class CreateClass(CreateView):
    model = Class
    form_class = CreateClassForm
    template_name = "Class_Management/create_class.html"
    success_url = reverse_lazy("list_class")


class UpdateClass(UpdateView):
    model = Class
    form_class = UpdateClassForm
    template_name = "Class_Management/update_class.html"
    success_url = reverse_lazy("list_class")


class DeleteClass(DeleteView):
    model = Class
    template_name = "Class_Management/delete_class.html"
    success_url = reverse_lazy("list_class")


def createLecturerClassAssignment(request, id):
    try:
        semester = request.POST.get("semester")
        course = request.POST.get("course")
        lecturer = request.POST.get("lecturer")
        chosenlecturer = lecturer[1:len(lecturer) - 1]
        updateLecturerClass = Class.objects.get(id=id)
        updateLecturerClass.semester = Semester.objects.get(id=semester)
        updateLecturerClass.course = Course.objects.get(id=course)
        updateLecturerClass.lecturer = Lecturer.objects.get(id=chosenlecturer)
        updateLecturerClass.save()
        message = updateLecturerClass.lecturer.firstname + " " + updateLecturerClass.lecturer.lastname + \
            " has been assigned to teach this class."
    except:
        message = "Unable to assign a Lecturer to this class."
    context = {"message": message}
    return render(request, "Class_Management/create_lecturer_class_assignment.html", context)


def createLecturerClassAssignmentForm(request, id):
    classID = Class.objects.get(id=id)
    lecturers = Lecturer.objects.all()
    context = {"class": classID, "lecturers": lecturers}
    return render(request, "Class_Management/create_lecturer_class_assignment_form.html", context)


def updateLecturerClassAssignment(request, id):
    try:
        semester = request.POST.get("semester")
        course = request.POST.get("course")
        lecturer = request.POST.get("lecturer")
        chosenlecturer = lecturer[1:len(lecturer) - 1]
        updateLecturerClass = Class.objects.get(id=id)
        updateLecturerClass.semester = Semester.objects.get(id=semester)
        updateLecturerClass.course = Course.objects.get(id=course)
        updateLecturerClass.lecturer = Lecturer.objects.get(id=chosenlecturer)
        updateLecturerClass.save()
        message = "The Lecturer has been changed to " + updateLecturerClass.lecturer.firstname + " " + \
                  updateLecturerClass.lecturer.lastname + "."
    except:
        message = "Unable to change the Lecturer to this class."
    context = {"message": message}
    return render(request, "Class_Management/update_lecturer_class_assignment.html", context)


def updateLecturerClassAssignmentForm(request, id):
    classID = Class.objects.get(id=id)
    lecturers = Lecturer.objects.all()
    context = {"class": classID, "lecturers": lecturers}
    return render(request, "Class_Management/update_lecturer_class_assignment_form.html", context)


def removeLecturerClassAssignment(request, id):
    try:
        semester = request.POST.get("semester")
        course = request.POST.get("course")
        lecturer = request.POST.get("lecturer")
        removeLecturerClass = Class.objects.get(id=id)
        removeLecturerClass.semester = Semester.objects.get(id=semester)
        removeLecturerClass.course = Course.objects.get(id=course)
        removeLecturerClass.lecturer = None
        removeLecturerClass.save()
        oldLecturer = Lecturer.objects.get(id=lecturer)
        message = oldLecturer.firstname + " " + oldLecturer.lastname + " has been removed as Lecturer from " + \
                  removeLecturerClass.number + " " + removeLecturerClass.course.name + " " \
                  + str(removeLecturerClass.semester.year) + " " + removeLecturerClass.semester.semester + "."
    except:
        message = "Unable to un-assign the Lecturer to this class."
    context = {"message": message}
    return render(request, "Class_Management/delete_lecturer_class_assignment.html", context)


def removeLecturerClassAssignmentForm(request, id):
    classID = Class.objects.get(id=id)
    context = {"class": classID}
    return render(request, "Class_Management/delete_lecturer_class_assignment_form.html", context)


class ListLecturer(ListView):
    model = Lecturer
    template_name = 'Lecturer_Management/list_lecturer.html'
    ordering = ['lastname', 'firstname']


def lecturerDetail(request, id):
    lecturer = Lecturer.objects.get(id=id)
    lecturerClasses = Class.objects.filter(lecturer_id=id)
    for course in lecturerClasses:
        if course.lecturer_id == id:
            lecturer.course.add(course.course_id)
    context = {"lecturer": lecturer}
    return render(request, "Lecturer_Management/lecturer_detail.html", context)


def createLecturer(request):
    firstName = request.POST.get("firstname")
    lastName = request.POST.get("lastname")
    email = request.POST.get("emailAddress")
    dob = request.POST.get("DOB")
    try:
        username = firstName + lastName
        dob = str(dob).split(" ")[0]
        password = dob.replace("-", "")
        newUser = User.objects.create_user(username=username)
        newUser.first_name = firstName
        newUser.last_name = lastName
        newUser.email = email
        newUser.set_password(password)
        newUser.save()
        newUser.groups.add(2)
        newUser.save()
        newLecturer = Lecturer()
        newLecturer.id = newUser.id
        newLecturer.firstname = firstName
        newLecturer.lastname = lastName
        newLecturer.email = email
        newLecturer.DOB = dob
        newLecturer.save()
        message = firstName + " " + lastName + " has been created as a Lecturer."
    except:
        message = "Cannot create this Lecturer."
    context = {"message": message}
    return render(request, "Lecturer_Management/create_lecturer.html", context)


def createLecturerForm(request):
    return render(request, "Lecturer_Management/create_lecturer_form.html", None)


def updateLecturer(request, id):
    firstName = request.POST.get("firstname")
    lastName = request.POST.get("lastname")
    email = request.POST.get("emailAddress")
    dob = request.POST.get("DOB")
    try:
        updateLecturer = Lecturer.objects.get(id=id)
        username = updateLecturer.firstname + updateLecturer.lastname
        updateLecturer.firstname = firstName
        updateLecturer.lastname = lastName
        updateLecturer.email = email
        updateLecturer.DOB = dob
        updateLecturer.save(update_fields=['firstname', 'lastname', 'email', 'DOB'])
        updateUser = User.objects.get(username=username)
        updateUser.first_name = firstName
        updateUser.last_name = lastName
        updateUser.email = email
        updateUser.username = firstName + lastName
        updateUser.save()
        message = firstName + " " + lastName + " has been updated."
    except:
        message = "Cannot update this lecturer: " + firstName + " " + lastName + "."
    context = {"message": message}
    return render(request, "Lecturer_Management/update_lecturer.html", context)


def updateLecturerForm(request, id):
    lecturer = Lecturer.objects.get(id=id)
    context = {"lecturer": lecturer}
    return render(request, "Lecturer_Management/update_lecturer_form.html", context)


def deleteLecturer(request, id):
    try:
        lecturer = Lecturer.objects.get(id=id)
        firstname = lecturer.firstname
        lastname = lecturer.lastname
        username = firstname + lastname
        user = User.objects.get(username=username)
        lecturer.delete()
        user.delete()
        message = firstname + " " + lastname + " has been deleted."
    except:
        message = "Cannot delete this lecturer."
    context = {"message": message}
    return render(request, "Lecturer_Management/delete_lecturer.html", context)


def deleteLecturerForm(request, id):
    lecturer = Lecturer.objects.get(id=id)
    context = {"lecturer": lecturer}
    return render(request, "Lecturer_Management/delete_lecturer_form.html", context)


def listStudent(request):
    students = Student.objects.all()
    studentEnrollments = StudentEnrollment.objects.all()
    context = {"students": students, "studentEnrollments": studentEnrollments}
    return render(request, 'Student_Management/list_student.html', context)


def studentDetail(request, id):
    student = Student.objects.get(id=id)
    try:
        classes = StudentEnrollment.objects.filter(studentID_id=id)
    except:
        classes = None
    context = {"student": student, "classes": classes}
    return render(request, 'Student_Management/student_detail.html', context)


def createStudent(request):
    firstName = request.POST.get("firstname")
    lastName = request.POST.get("lastname")
    email = request.POST.get("emailAddress")
    dob = request.POST.get("DOB")
    try:
        username = firstName + lastName
        dob = str(dob).split(" ")[0]
        password = dob.replace("-", "")
        newUser = User.objects.create_user(username=username)
        newUser.first_name = firstName
        newUser.last_name = lastName
        newUser.email = email
        newUser.set_password(password)
        newUser.save()
        newUser.groups.add(3)
        newUser.save()
        newStudent = Student()
        newStudent.id = newUser.id
        newStudent.firstname = firstName
        newStudent.lastname = lastName
        newStudent.email = email
        newStudent.DOB = dob
        newStudent.save()
        message = firstName + " " + lastName + " has been created as a Student."
    except:
        message = "Cannot create this Student."
    context = {"message": message}
    return render(request, "Student_Management/create_student.html", context)


def createStudentForm(request):
    return render(request, "Student_Management/create_student_form.html", None)


def updateStudent(request, id):
    firstName = request.POST.get("firstname")
    lastName = request.POST.get("lastname")
    email = request.POST.get("emailAddress")
    dob = request.POST.get("DOB")
    try:
        updateStudent = Student.objects.get(id=id)
        username = updateStudent.firstname + updateStudent.lastname
        updateStudent.firstname = firstName
        updateStudent.lastname = lastName
        updateStudent.email = email
        updateStudent.DOB = dob
        updateStudent.save(update_fields=['firstname', 'lastname', 'email', 'DOB'])
        updateUser = User.objects.get(username=username)
        updateUser.first_name = firstName
        updateUser.last_name = lastName
        updateUser.email = email
        updateUser.username = firstName + lastName
        updateUser.save()
        message = firstName + " " + lastName + " has been updated."
    except:
        message = "Cannot update this student: " + firstName + " " + lastName + "."
    context = {"message": message}
    return render(request, "Student_Management/update_student.html", context)


def updateStudentForm(request, id):
    student = Student.objects.get(id=id)
    context = {"student": student}
    return render(request, "Student_Management/update_student_form.html", context)


def deleteStudent(request, id):
    try:
        student = Student.objects.get(id=id)
        firstname = student.firstname
        lastname = student.lastname
        student.delete()
        user = User.objects.get(id=id)
        user.delete()
        message = firstname + " " + lastname + " has been deleted."
    except:
        message = "Cannot delete this student."
    context = {"message": message}
    return render(request, "Student_Management/delete_student.html", context)


def deleteStudentForm(request, id):
    student = Student.objects.get(id=id)
    context = {"student": student}
    return render(request, "Student_Management/delete_student_form.html", context)


def createStudentEnrollmentForm(request, id):
    classIDs = Class.objects.all()
    student = Student.objects.get(id=id)
    context = {"classes": classIDs, "student": student}
    return render(request, "Student_Management/enroll_student_form.html", context)


def createStudentEnrollment(request, id):
    student = Student.objects.get(id=id)
    classID = request.POST.get("classID")
    chosenClass = classID[1:len(classID) - 1]
    try:
        studentEnrollment = StudentEnrollment()
        studentEnrollment.studentID_id = id
        studentEnrollment.classID_id = chosenClass
        studentEnrollment.save()
        print(studentEnrollment.studentID)
        message = studentEnrollment.studentID.firstname + " " + studentEnrollment.studentID.lastname + \
                  " has been enrolled in " + str(studentEnrollment.classID.semester.year) + "'s Semester " + \
                  studentEnrollment.classID.semester.semester + " class number " + studentEnrollment.classID.number + \
                  " for " + studentEnrollment.classID.course.code + " " + studentEnrollment.classID.course.name + "."

    except:
        message = "The enrollment for " + student.firstname + " " + student.lastname + " was unsuccessful."
    context = {"message": message}
    return render(request, "Student_Management/enroll_student.html", context)


def addGrade(request, id):
    grade = request.POST.get("grade")
    try:
        studentGrade = StudentEnrollment.objects.get(id=id)
        studentGrade.grade = grade
        studentGrade.gradeTime.now()
        studentGrade.save(update_fields=['grade', 'gradeTime'])
        message = "Grade has been saved."
        lecturer = studentGrade.classID.lecturer.id
    except:
        message = "Cannot award grade to this student."
        lecturer = ""
    context = {"message": message, "lecturer": lecturer}
    return render(request, "Student_Management/add_grade.html", context)


def addGradeForm(request, id):
    studentEnrollment = StudentEnrollment.objects.get(id=id)
    context = {"studentEnrollment": studentEnrollment}
    return render(request, "Student_Management/add_grade_form.html", context)


def removeStudentEnrollment(request, id):
    try:
        studentEnrollment = StudentEnrollment.objects.get(id=id)

        firstname = studentEnrollment.studentID.firstname
        lastname = studentEnrollment.studentID.lastname
        classID = str(studentEnrollment.classID.number)
        semesterYear = str(studentEnrollment.classID.semester.year)
        semesterSemester = studentEnrollment.classID.semester.semester
        courseCode = studentEnrollment.classID.course.code
        courseName = studentEnrollment.classID.course.name
        studentEnrollment.delete()
        message = firstname + " " + lastname + " has been un-enrolled from class: " + classID + " " + courseCode + \
                  " " + courseName + " in " + semesterSemester + " " + semesterYear + "."
        print(message)
    except:
        message = "Unable to un-enroll the student for this class."
    context = {"message": message}
    return render(request, "Student_Management/remove_student_enrollment.html", context)


def removeStudentEnrollmentForm(request, id):
    studentEnrollment = StudentEnrollment.objects.get(id=id)
    context = {"studentEnrollment": studentEnrollment}
    return render(request, "Student_Management/remove_student_enrollment_form.html", context)


def studentGrades(request, id):
    studentEnrollments = StudentEnrollment.objects.filter(studentID=id)
    student = Student.objects.get(id=id)
    context = {"studentEnrollments": studentEnrollments, "student": student}
    return render(request, "Student_Management/student_grades_detail.html", context)


def bulkStudentUpload(request):
    context={}
    if request.method == 'POST' and request.FILES['theFile']:
        theFile = request.FILES['theFile']
        # fs = FileSystemStorage()
        file_save = default_storage.save(theFile.name, theFile)
        storage.child("files/" + theFile.name).put("media/" + theFile.name)
        # filename = fs.save(theFile.name, theFile)
        # uploaded_file_url = fs.url(filename)
        import pandas as pd
        excel_data = pd.read_excel(theFile)
        data = pd.DataFrame(excel_data)
        ids = data['ID'].tolist()
        firstnames = data['Firstname'].tolist()
        lastnames = data['Lastname'].tolist()
        emails = data['Email'].tolist()
        dobs = data['DOB'].tolist()
        classes = data['Class'].tolist()
        i = 0
        while i < len(firstnames):
            id = ids[i]
            firstname = firstnames[i]
            lastname = lastnames[i]
            email = emails[i]
            dob = dobs[i]
            dob = str(dob).split(" ")[0]
            classID = classes[i]
            try:
                student = Student.objects.get(id=id)
            except ObjectDoesNotExist:
                username = firstname + lastname
                password = dob.replace("-", "")
                user = User.objects.create_user(username=username, id=id, password=password)
                user.first_name = firstname
                user.last_name = lastname
                user.email = email
                user.groups.add(3)
                user.save()
                student = Student(id=id, firstname=firstname, lastname=lastname, DOB=dob, email=email)
                student.save()
            try:
                classNumber = Class.objects.get(number=classID)
                try:
                    StudentEnrollment.objects.get(studentID=student, classID=classNumber)
                    pass
                except ObjectDoesNotExist:
                    studentEnrollment = StudentEnrollment(studentID=student, classID=classNumber)
                    studentEnrollment.save()
            except ObjectDoesNotExist:
                context = {'message': 'Unable to upload this file. Please check that all classes have been created.'}
            i += 1
        if len(context) > 0:
            pass
        else:
            context = {'':''}
        return render(request, 'Student_Management/bulk_student_upload.html', context)
    else:
        return render(request, 'Student_Management/bulk_student_upload.html')




def sendEmail(request, id):
    studentEnrollment = StudentEnrollment.objects.get(id=id)
    emailAddress = studentEnrollment.studentID.email
    emailSubject = "Your Grade Has Been Published"
    emailBody = "Hello " + studentEnrollment.studentID.firstname + ". For your course " + \
                studentEnrollment.classID.course.code + " " + studentEnrollment.classID.course.name + \
                " you have earned a grade of " + studentEnrollment.grade + ". Well done! Best regards " + \
                studentEnrollment.classID.lecturer.firstname + " " + studentEnrollment.classID.lecturer.lastname + "."
    senderEmail = 'annamccollnz@gmail.com'
    try:
        send_mail(emailSubject, emailBody, senderEmail, [emailAddress], fail_silently=False)
        message = "Your email was sent to " + emailAddress + " successfully."
    except:
        message = "Your email failed to be sent to " + emailAddress + "."
    context = {'message': message}
    return render(request, 'Student_Management/send_email.html', context)