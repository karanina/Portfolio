from django.urls import path
from . import views

from gradebook.views import index, CreateSemester, ListSemester, SemesterDetail, UpdateSemester, DeleteSemester, \
    ListCourse, CourseDetail, CreateCourse, UpdateCourse, DeleteCourse, ListClass, ClassDetail, CreateClass, \
    UpdateClass, DeleteClass, ListLecturer, addGradeForm, addGrade, createLecturer, createLecturerForm, \
    updateLecturer, updateLecturerForm, listStudent, updateLecturerClassAssignment, updateLecturerClassAssignmentForm, \
    createLecturerClassAssignment, createLecturerClassAssignmentForm, removeLecturerClassAssignment, \
    removeLecturerClassAssignmentForm, lecturerDetail, createStudent, createStudentForm, updateStudentForm, \
    updateStudent, createStudentEnrollmentForm, createStudentEnrollment, studentDetail, removeStudentEnrollment, \
    removeStudentEnrollmentForm, studentGrades, bulkStudentUpload, deleteLecturer, deleteLecturerForm, deleteStudent, \
    deleteStudentForm, sendEmail

urlpatterns = [
    path('', index, name='index'),
    path('list_semester', ListSemester.as_view(), name='list_semester'),
    path('semester_detail/<int:pk>', SemesterDetail.as_view(), name='semester_detail'),
    path('create_semester', CreateSemester.as_view(), name='create_semester'),
    path('update_semester/<int:pk>', UpdateSemester.as_view(), name='update_semester'),
    path('delete_semester/<int:pk>', DeleteSemester.as_view(), name='delete_semester'),
    path('list_course', ListCourse.as_view(), name='list_course'),
    path('course_detail/<int:pk>', CourseDetail.as_view(), name='course_detail'),
    path('create_course', CreateCourse.as_view(), name='create_course'),
    path('update_course/<int:pk>', UpdateCourse.as_view(), name='update_course'),
    path('delete_course/<int:pk>', DeleteCourse.as_view(), name='delete_course'),
    path('list_class', ListClass.as_view(), name="list_class"),
    path('class_detail/<int:pk>', ClassDetail.as_view(), name='class_detail'),
    path('create_class', CreateClass.as_view(), name='create_class'),
    path('update_class/<int:pk>', UpdateClass.as_view(), name='update_class'),
    path('delete_class/<int:pk>', DeleteClass.as_view(), name='delete_class'),
    path('create_lecturer_class_assignment_form/<int:id>', createLecturerClassAssignmentForm,
         name='create_lecturer_class_assignment_form'),
    path('create_lecturer_class_assignment/<int:id>', createLecturerClassAssignment,
         name='create_lecturer_class_assignment'),
    path('update_lecturer_class_assignment/<int:id>', updateLecturerClassAssignment,
         name='update_lecturer_class_assignment'),
    path('update_lecturer_class_assignment_form/<int:id>', updateLecturerClassAssignmentForm,
         name='update_lecturer_class_assignment_form'),
    path('delete_lecturer_class_assignment_form/<int:id>', removeLecturerClassAssignmentForm,
         name='delete_lecturer_class_assignment_form'),
    path('delete_lecturer_class_assignment/<int:id>', removeLecturerClassAssignment,
         name='delete_lecturer_class_assignment'),
    path('list_lecturer', ListLecturer.as_view(), name='list_lecturer'),
    path('lecturer_detail/<int:id>', lecturerDetail, name='lecturer_detail'),
    path('create_lecturer', createLecturer, name='create_lecturer'),
    path('create_lecturer_form', createLecturerForm, name='create_lecturer_form'),
    path('update_lecturer/<int:id>', updateLecturer, name='update_lecturer'),
    path('update_lecturer_form/<int:id>', updateLecturerForm, name='update_lecturer_form'),
    path('delete_lecturer/<int:id>', deleteLecturer, name='delete_lecturer'),
    path('delete_lecturer_form/<int:id>', deleteLecturerForm, name='delete_lecturer_form'),
    path('list_student', listStudent, name='list_student'),
    path('student_detail/<int:id>', studentDetail, name='student_detail'),
    path('create_student_form', createStudentForm, name='create_student_form'),
    path('create_student', createStudent, name='create_student'),
    path('update_student_form/<int:id>', updateStudentForm, name='update_student_form'),
    path('update_student/<int:id>', updateStudent, name='update_student'),
    path('delete_student/<int:id>', deleteStudent, name='delete_student'),
    path('delete_student_form/<int:id>', deleteStudentForm, name='delete_student_form'),
    path('enroll_student_form/<int:id>', createStudentEnrollmentForm, name='enroll_student_form'),
    path('enroll_student/<int:id>', createStudentEnrollment, name='enroll_student'),
    path('add_grade/<int:id>', addGrade, name='add_grade'),
    path('add_grade_form/<int:id>', addGradeForm, name='add_grade_form'),
    path('remove_student_enrollment_form/<int:id>', removeStudentEnrollmentForm, name='remove_student_enrollment_form'),
    path('remove_student_enrollment/<int:id>', removeStudentEnrollment, name='remove_student_enrollment'),
    path('student_grades_detail/<int:id>', studentGrades, name='student_grades_detail'),
    path('bulk_student_upload', bulkStudentUpload, name='bulk_student_upload'),
    path('send_email/<int:id>', sendEmail, name='send_email'),
]