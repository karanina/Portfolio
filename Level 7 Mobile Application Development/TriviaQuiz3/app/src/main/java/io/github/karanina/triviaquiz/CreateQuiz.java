package io.github.karanina.triviaquiz;

import androidx.appcompat.app.AppCompatActivity;

import android.app.DatePickerDialog;
import android.content.Intent;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.DatePicker;
import android.widget.Spinner;
import android.widget.TextView;
import android.widget.Toast;

import org.jsoup.Jsoup;
import org.jsoup.safety.Safelist;

import java.util.ArrayList;
import java.util.Calendar;
import java.util.Locale;

import io.github.karanina.triviaquiz.model.Category;
import io.github.karanina.triviaquiz.model.Question;
import io.github.karanina.triviaquiz.model.Quiz;
import io.github.karanina.triviaquiz.rest.CategoryControllerRESTAPI;
import io.github.karanina.triviaquiz.rest.QuestionControllerRESTAPI;

public class CreateQuiz extends AppCompatActivity implements View.OnClickListener {

    Button btn_startDate, btn_endDate, btn_generateQuestions, btn_previewQuiz, btn_saveQuiz;
    Spinner spin_category, spin_difficulty;
    TextView et_quizName, et_previewQuiz, tv_startDate, tv_endDate;
    QuestionControllerRESTAPI questionControllerRESTAPI;
    Quiz quiz;
    String userID, accessLevel;
    String startDate, endDate;
    ArrayList<Category> categoryArrayList = new ArrayList<>();
    CategoryControllerRESTAPI categoryControllerRESTAPI;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_create_quiz);

        Intent intent = getIntent();
        userID = intent.getStringExtra("userID");
        accessLevel = intent.getStringExtra("accessLevel");

        if (accessLevel.equals("Admin")) {

            et_quizName = findViewById(R.id.et_quizName);
            btn_startDate = findViewById(R.id.btn_startDate);
            tv_startDate = findViewById(R.id.tv_startDate);
            btn_endDate = findViewById(R.id.btn_endDate);
            tv_endDate = findViewById(R.id.tv_endDate);
            btn_generateQuestions = findViewById(R.id.btn_generateQuestions);
            btn_previewQuiz = findViewById(R.id.btn_previewQuiz);
            et_previewQuiz = findViewById(R.id.et_quizPreview);
            btn_saveQuiz = findViewById(R.id.btn_saveQuiz);
            spin_category = findViewById(R.id.spin_category);
            spin_difficulty = findViewById(R.id.spin_difficulty);

            btn_startDate.setOnClickListener(this);
            btn_endDate.setOnClickListener(this);
            btn_generateQuestions.setOnClickListener(this);
            btn_previewQuiz.setOnClickListener(this);
            btn_saveQuiz.setOnClickListener(this);

            categoryControllerRESTAPI = new CategoryControllerRESTAPI();
            categoryControllerRESTAPI.start(this, spin_category);

            ArrayAdapter<CharSequence> difficultyAdapter = ArrayAdapter.createFromResource(this,
                    R.array.difficulty, android.R.layout.simple_spinner_item);
            difficultyAdapter.setDropDownViewResource(android.R.layout.simple_spinner_item);
            spin_difficulty.setAdapter(difficultyAdapter);
        }
    }



    @Override
    public void onClick(View view) {
        if (view.getId() == btn_startDate.getId()) {
            datePickerDialog("startDate");
        } else if (view.getId() == btn_endDate.getId()) {
            datePickerDialog("endDate");
        } else if (view.getId() == btn_generateQuestions.getId()) {
            String difficulty = spin_difficulty.getSelectedItem().toString().toLowerCase();
            String category = spin_category.getSelectedItem().toString();
            int catID = 0;
            categoryArrayList = categoryControllerRESTAPI.getCategories();
            for (Category cat : categoryArrayList){
                if (cat.getName().equals(category)){
                    catID = cat.getId();
                    break;
                }
            }
            questionControllerRESTAPI = new QuestionControllerRESTAPI();
            questionControllerRESTAPI.start(difficulty, catID);
            if (questionControllerRESTAPI != null) {
                quiz = questionControllerRESTAPI.getQuiz();
            }
        } else if (view.getId() == btn_previewQuiz.getId()) {
            try{
            quiz.setName(et_quizName.getText().toString());
            quiz.setStartDate(startDate);
            quiz.setEndDate(endDate);
            StringBuilder questionList = new StringBuilder();
            for (Question question : quiz.getQuestions()){
                questionList.append("Question: " + question.getQuestion());
                questionList.append("\nCorrect Answer: " + question.getCorrect_answer());
                questionList.append("\nIncorrect Answers: ");
                for (String answer : question.getIncorrect_answers()){
                    questionList.append(answer + ".");
                }
                questionList.append("\n");
            }
            String tempQuestions = String.valueOf(Jsoup.parse(String.valueOf(questionList)));
                Safelist safelist = new Safelist();
            String questions = (Jsoup.clean(tempQuestions,safelist));
            et_previewQuiz.setText(questions);
            et_previewQuiz.setVisibility(View.VISIBLE);}
            catch (NullPointerException e){
                et_previewQuiz.setText(R.string.preview_questions_wait_message);
                et_previewQuiz.setVisibility(View.VISIBLE);
                e.printStackTrace();
            }
        }
        else if (view.getId() == btn_saveQuiz.getId()){
            QuizDAO quizDAO =  new QuizDAO();
            quizDAO.add(quiz);
            Toast.makeText(this, "Quiz has been created", Toast.LENGTH_SHORT).show();
            finish();
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