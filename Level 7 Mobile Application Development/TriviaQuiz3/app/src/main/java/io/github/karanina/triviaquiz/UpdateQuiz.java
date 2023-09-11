package io.github.karanina.triviaquiz;

import androidx.annotation.NonNull;
import androidx.appcompat.app.AppCompatActivity;

import android.app.DatePickerDialog;
import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.DatePicker;
import android.widget.Spinner;
import android.widget.TextView;
import android.widget.Toast;

import com.google.firebase.database.DataSnapshot;
import com.google.firebase.database.DatabaseError;
import com.google.firebase.database.Exclude;
import com.google.firebase.database.ValueEventListener;

import java.util.ArrayList;
import java.util.Calendar;
import java.util.HashMap;

import io.github.karanina.triviaquiz.model.Category;
import io.github.karanina.triviaquiz.model.Question;
import io.github.karanina.triviaquiz.model.Quiz;
import io.github.karanina.triviaquiz.rest.CategoryControllerRESTAPI;
import io.github.karanina.triviaquiz.rest.QuestionControllerRESTAPI;

public class UpdateQuiz extends AppCompatActivity implements View.OnClickListener {

    Button btn_changeStartDate, btn_changeEndDate, btn_updateQuiz;
    TextView et_quizName, tv_startDate, tv_endDate, tv_category, tv_difficulty;
    QuizDAO quizDAO;
    Quiz quiz;
    String userID, accessLevel, quizKey;
    String startDate, endDate;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_update_quiz);

        Intent intent = getIntent();
        userID = intent.getStringExtra("userID");
        accessLevel = intent.getStringExtra("accessLevel");
        quizKey = intent.getStringExtra("quizKey");

        if (accessLevel.equals("Admin")) {

            et_quizName = findViewById(R.id.et_quizName);
            btn_changeStartDate = findViewById(R.id.btn_changeStartDate);
            tv_startDate = findViewById(R.id.tv_startDate);
            btn_changeEndDate = findViewById(R.id.btn_changeEndDate);
            tv_endDate = findViewById(R.id.tv_endDate);
            btn_updateQuiz = findViewById(R.id.btn_updateQuiz);
            tv_category = findViewById(R.id.tv_category);
            tv_difficulty = findViewById(R.id.tv_difficulty);

            btn_changeStartDate.setOnClickListener(this);
            btn_changeEndDate.setOnClickListener(this);
            btn_updateQuiz.setOnClickListener(this);

            quizDAO = new QuizDAO();
            quizDAO.getQuiz(quizKey).addListenerForSingleValueEvent(new ValueEventListener() {
                @Override
                public void onDataChange(@NonNull DataSnapshot snapshot) {
                    quiz = snapshot.getValue(Quiz.class);
                    et_quizName.setText(quiz.getName());
                    tv_category.setText(quiz.getCategory());
                    tv_difficulty.setText(quiz.getDifficulty());
                    tv_startDate.setText(quiz.getStartDate());
                    tv_endDate.setText(quiz.getEndDate());
                }

                @Override
                public void onCancelled(@NonNull DatabaseError error) {
                    error.toString();
                }
            });
        }
    }


    @Override
    public void onClick(View view) {
        if (view.getId() == btn_changeStartDate.getId()) {
            datePickerDialog("startDate");
        } else if (view.getId() == btn_changeEndDate.getId()) {
            datePickerDialog("endDate");
        } else if (view.getId() == btn_updateQuiz.getId()) {
            HashMap<String, Object> quizHashmap = new HashMap<>();
            quizHashmap.put("name", et_quizName.getText().toString());
            quizHashmap.put("category", quiz.getCategory());
            quizHashmap.put("difficulty", quiz.getDifficulty());
            quizHashmap.put("questions", quiz.getQuestions());
            quizHashmap.put("startDate", startDate);
            quizHashmap.put("endDate", endDate);
            quizDAO.update(quizKey, quizHashmap);
            Toast.makeText(this, "Quiz updated.", Toast.LENGTH_SHORT).show();
            Intent intent = new Intent();
            intent.putExtra("userID", userID);
            intent.putExtra("accessLevel", accessLevel);
            intent.setClass(this, QuizList.class);
            startActivity(intent);
        }
    }

    public void datePickerDialog(String dateType) {
        // Get current date
        final Calendar currentDate = Calendar.getInstance();
        int currentYear = currentDate.get(Calendar.YEAR);
        int currentMonth = currentDate.get(Calendar.MONTH);
        int currentDay = currentDate.get(Calendar.DAY_OF_MONTH);
        DatePickerDialog datePickerDialog = new DatePickerDialog(this, new DatePickerDialog.OnDateSetListener() {
            @Override
            public void onDateSet(DatePicker view, int year, int month, int dayOfMonth) {
                String date = dayOfMonth + "-" + (month + 1) + "-" + year;
                switch (dateType) {
                    case "startDate":
                        startDate = date;
                        tv_startDate.setText(startDate);
                        break;
                    case "endDate":
                        endDate = date;
                        tv_endDate.setText(endDate);
                        break;
                }
            }
        }, currentYear, currentMonth, currentDay);
        datePickerDialog.show();
    }
}