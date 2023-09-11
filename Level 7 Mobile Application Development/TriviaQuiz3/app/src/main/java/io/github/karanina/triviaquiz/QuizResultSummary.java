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

import io.github.karanina.triviaquiz.model.Quiz;

public class QuizResultSummary extends AppCompatActivity implements View.OnClickListener{

    TextView db_quizName, tv_resultMessage;
    Button btn_mainMenu;
    String userID, accessLevel, quizKey;
    int questionsAnswered, questionsCorrect;
    QuizDAO quizDAO;
    Quiz quiz;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_quiz_result_summary);

        Intent intent = getIntent();
        userID = intent.getStringExtra("userID");
        accessLevel = intent.getStringExtra("accessLevel");
        quizKey = intent.getStringExtra("quizKey");
        questionsAnswered = intent.getIntExtra("questionsAnswered",0);
        questionsCorrect = intent.getIntExtra("questionsCorrect", 0);

        db_quizName = findViewById(R.id.db_quizName);
        tv_resultMessage = findViewById(R.id.tv_resultMessage);
        btn_mainMenu = findViewById(R.id.btn_mainMenu);

        loadQuiz();
        String resultMessage = "Congratulations! You scored " + questionsCorrect + " out of " + questionsAnswered + ".";
        tv_resultMessage.setText(resultMessage);

        btn_mainMenu.setOnClickListener(this);


    }
    private void loadQuiz() {
        quizDAO = new QuizDAO();
        quizDAO.getQuiz(quizKey).addListenerForSingleValueEvent(new ValueEventListener() {
            @Override
            public void onDataChange(@NonNull DataSnapshot snapshot) {
                quiz = snapshot.getValue(Quiz.class);
                Log.d("QUIZ", quiz.toString());

                db_quizName.setText(quiz.getName());
            }

            @Override
            public void onCancelled(@NonNull DatabaseError error) {

            }
        });

    }

    @Override
    public void onClick(View view) {
        if (view.getId() == btn_mainMenu.getId()){
            Intent intent = new Intent();
            intent.setClass(this, MainActivity.class);
            intent.putExtra("accessLevel", accessLevel);
            intent.putExtra("userID", userID);
            startActivity(intent);

        }
    }
}