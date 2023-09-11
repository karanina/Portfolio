package io.github.karanina.triviaquiz;

import androidx.annotation.NonNull;
import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;

import com.google.firebase.database.DataSnapshot;
import com.google.firebase.database.DatabaseError;
import com.google.firebase.database.ValueEventListener;

import org.jsoup.Jsoup;
import org.jsoup.safety.Safelist;

import java.util.ArrayList;
import java.util.Random;

import io.github.karanina.triviaquiz.model.Question;
import io.github.karanina.triviaquiz.model.Quiz;
import io.github.karanina.triviaquiz.model.User;

public class TakeQuiz extends AppCompatActivity implements View.OnClickListener {

    String userID;
    String accessLevel;
    String quizKey;
    int questionsAnswered;
    int questionsCorrect;
    int correctAnswer;
    int submittedAnswer;
    QuizDAO quizDAO;
    Quiz quiz;
    Question question;
    String questionStr;
    TextView db_quizName, db_question, tv_result;
    Button btn_answer1, btn_answer2, btn_answer3, btn_answer4, btn_nextQuestion;
    ArrayList<String> answers = new ArrayList<>();

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_take_quiz);

        Intent intent = getIntent();
        userID = intent.getStringExtra("userID");
        accessLevel = intent.getStringExtra("accessLevel");
        quizKey = intent.getStringExtra("quizKey");
        questionsAnswered = intent.getIntExtra("questionsAnswered",0);
        questionsCorrect = intent.getIntExtra("questionsCorrect", 0);

        loadQuiz();

        db_quizName = findViewById(R.id.db_quizName);
        db_question = findViewById(R.id.db_question);
        tv_result = findViewById(R.id.db_result);
        btn_answer1 = findViewById(R.id.btn_answer1);
        btn_answer2 = findViewById(R.id.btn_answer2);
        btn_answer3 = findViewById(R.id.btn_answer3);
        btn_answer4 = findViewById(R.id.btn_answer4);
        btn_nextQuestion = findViewById(R.id.btn_nextQuestion);

        if (questionsAnswered == 9 ){
            btn_nextQuestion.setText("Get Results");
        }

        btn_answer1.setOnClickListener(this);
        btn_answer2.setOnClickListener(this);
        btn_answer3.setOnClickListener(this);
        btn_answer4.setOnClickListener(this);
        btn_nextQuestion.setOnClickListener(this);


    }

    private String transformText(String text){
        String toTransform = String.valueOf(Jsoup.parse(String.valueOf(text)));
        Safelist safelist = new Safelist();
        return Jsoup.clean(toTransform,safelist);
    }
    private void loadQuestion() {
        question = quiz.getQuestions().get(questionsAnswered);
        questionStr = transformText(quiz.getQuestions().get(questionsAnswered).getQuestion());
    }

    private void loadAnswers(){
        for (String answer : question.getIncorrect_answers()){
            answers.add(transformText(answer));
        }
        Random r = new Random();
        correctAnswer = r.nextInt(3);
        answers.add(correctAnswer, transformText(question.getCorrect_answer()));
    }
    private void loadQuiz() {
        quizDAO = new QuizDAO();
        quizDAO.getQuiz(quizKey).addListenerForSingleValueEvent(new ValueEventListener() {
            @Override
            public void onDataChange(@NonNull DataSnapshot snapshot) {
                quiz = snapshot.getValue(Quiz.class);
                Log.d("QUIZ", quiz.toString());

                loadQuestion();
                db_quizName.setText(quiz.getName());
                db_question.setText(questionStr);

                loadAnswers();
                btn_answer1.setText(answers.get(0));
                btn_answer2.setText(answers.get(1));
                btn_answer3.setText(answers.get(2));
                btn_answer4.setText(answers.get(3));
            }

            @Override
            public void onCancelled(@NonNull DatabaseError error) {

            }
        });
    }

    @Override
    public void onClick(View view) {
        
        if (view.getId() == btn_answer1.getId()){
            showResult(0);
        }
        else if (view.getId() == btn_answer2.getId()){
            showResult(1);
        }
        else if (view.getId() == btn_answer3.getId()){
            showResult(2);
        }
        else if (view.getId() == btn_answer4.getId()){
            showResult(3);
        }
        else if (view.getId() == btn_nextQuestion.getId()){
            Intent intent = new Intent();
            if (questionsAnswered == 10) {
                UserDAO userDAO = new UserDAO();
                userDAO.get(userID).addListenerForSingleValueEvent(new ValueEventListener() {
                    @Override
                    public void onDataChange(@NonNull DataSnapshot snapshot) {
                        User user = snapshot.getValue(User.class);
                        user.setUserKey(snapshot.getKey());
                        user.addParticipatedQuiz(quizKey, questionsCorrect);
                        userDAO.updateParticipatedQuizzes(user);
                    }

                    @Override
                    public void onCancelled(@NonNull DatabaseError error) {

                    }
                });

                intent.setClass(this, QuizResultSummary.class);
            }
            else {
                intent.setClass(this, TakeQuiz.class);
            }
            intent.putExtra("quizKey", quizKey);
            intent.putExtra("accessLevel", accessLevel);
            intent.putExtra("userID", userID);
            intent.putExtra("questionsAnswered", questionsAnswered);
            intent.putExtra("questionsCorrect", questionsCorrect);
            startActivity(intent);
        }
    }

    private void showResult(int submittedAnswer) {
        questionsAnswered += 1;
        btn_answer1.setVisibility(View.GONE);
        btn_answer2.setVisibility(View.GONE);
        btn_answer3.setVisibility(View.GONE);
        btn_answer4.setVisibility(View.GONE);

        if (submittedAnswer == correctAnswer){
            questionsCorrect += 1;
            tv_result.setText("Correct!");
        }
        else{
            tv_result.setText("Incorrect. The correct answer was " + question.getCorrect_answer() + ".");
        }
        tv_result.setVisibility(View.VISIBLE);
        btn_nextQuestion.setVisibility(View.VISIBLE);
    }
}