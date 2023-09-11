package io.github.karanina.triviaquiz;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;

import com.google.firebase.auth.FirebaseAuth;
import com.google.firebase.auth.FirebaseUser;

import io.github.karanina.triviaquiz.rest.QuestionControllerRESTAPI;

public class MainActivity extends AppCompatActivity implements View.OnClickListener {

    TextView btn_ongoing, btn_upcoming, btn_past, btn_participated,
            btn_allQuizzes, btn_createQuiz;
    Button btn_logout, btn_registerAdminUser;
    String userID, accessLevel;
    FirebaseAuth firebaseAuth;


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        Intent intent = getIntent();
        userID = intent.getStringExtra("userID");
        accessLevel = intent.getStringExtra("accessLevel");

        btn_ongoing = findViewById(R.id.btn_ongoing);
        btn_upcoming = findViewById(R.id.btn_upcoming);
        btn_past = findViewById(R.id.btn_past);
        btn_participated = findViewById(R.id.btn_participated);
        btn_allQuizzes = findViewById(R.id.btn_allQuizes);
        btn_createQuiz = findViewById(R.id.btn_createQuiz);
        btn_registerAdminUser = findViewById(R.id.btn_registerAdmin);
        btn_logout = findViewById(R.id.btn_logout);

        if (accessLevel != null) {
            if (accessLevel.equals("Admin")) {
                btn_ongoing.setVisibility(View.GONE);
                btn_upcoming.setVisibility(View.GONE);
                btn_past.setVisibility(View.GONE);
                btn_participated.setVisibility(View.GONE);
                btn_registerAdminUser.setVisibility(View.VISIBLE);
                btn_allQuizzes.setVisibility(View.VISIBLE);
                btn_createQuiz.setVisibility(View.VISIBLE);

                btn_registerAdminUser.setOnClickListener(this);
                btn_allQuizzes.setOnClickListener(this);
                btn_createQuiz.setOnClickListener(this);

            } else {
                btn_ongoing.setOnClickListener(this);
                btn_upcoming.setOnClickListener(this);
                btn_past.setOnClickListener(this);
                btn_participated.setOnClickListener(this);
            }
        }
        btn_logout.setOnClickListener(this);
        firebaseAuth = FirebaseAuth.getInstance();
    }

    @Override
    protected void onStart() {
        super.onStart();
        FirebaseUser user = firebaseAuth.getCurrentUser();
        if (user == null) {
            Intent intent = new Intent();
            intent.setClass(this, Login.class);
            startActivity(intent);
        }
    }

    @Override
    public void onClick(View view) {
        Intent intent = new Intent();
        if (view.getId() == btn_logout.getId()) {
            firebaseAuth.signOut();
            intent.setClass(MainActivity.this, Login.class);
        }
        else if(view.getId() == btn_registerAdminUser.getId()){
            intent.setClass(MainActivity.this, Registration.class);
            intent.putExtra("accessLevel", "Admin");
            intent.putExtra("userID", userID);
        }
        else {
            intent.putExtra("userID", userID);
            intent.putExtra("accessLevel", accessLevel);

            if (view.getId() == btn_createQuiz.getId()) {
                intent.setClass(MainActivity.this, CreateQuiz.class);
            }
            else {
                intent.setClass(MainActivity.this, QuizList.class);

                if (view.getId() == btn_allQuizzes.getId()) {
                    intent.putExtra("listType", "all");
                } else if (view.getId() == btn_ongoing.getId()) {
                    intent.putExtra("listType", "ongoing");
                } else if (view.getId() == btn_upcoming.getId()) {
                    intent.putExtra("listType", "upcoming");
                } else if (view.getId() == btn_past.getId()) {
                    intent.putExtra("listType", "past");
                } else if (view.getId() == btn_participated.getId()) {
                    intent.putExtra("listType", "participated");
                }
            }
        }
        startActivity(intent);
    }
}