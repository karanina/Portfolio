package io.github.karanina.triviaquiz;

import androidx.annotation.NonNull;
import androidx.appcompat.app.AppCompatActivity;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import android.content.Intent;
import android.os.Bundle;
import android.widget.TextView;

import com.google.firebase.database.DataSnapshot;
import com.google.firebase.database.DatabaseError;
import com.google.firebase.database.ValueEventListener;

import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Date;
import java.util.HashMap;

import io.github.karanina.triviaquiz.model.Quiz;
import io.github.karanina.triviaquiz.model.User;

public class QuizList extends AppCompatActivity {

    TextView tv_quizListHeading;
    RecyclerView rv_quizList;
    QuizListRVAdapter adapter;
    QuizDAO quizDAO;
    String accessLevel, userID, listType;
    HashMap<String, Integer> participatedQuizzes;
    Date currentDate;
    SimpleDateFormat dateFormat;
    User user;

    //    @SuppressLint("SetTextI18n")
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_quiz_list);

        Intent intent = getIntent();
        accessLevel = intent.getStringExtra("accessLevel");
        userID = intent.getStringExtra("userID");
        listType = intent.getStringExtra("listType");

        quizDAO = new QuizDAO();

        dateFormat = new SimpleDateFormat("dd-MM-yyyy");
        currentDate = new Date();
        loadUserParticipatedQuizzes();
        loadQuizzes();

        tv_quizListHeading = findViewById(R.id.tv_quizListHeading);
        rv_quizList = findViewById(R.id.rv_quizList);

        adapter = new QuizListRVAdapter(this, userID, accessLevel, currentDate, dateFormat);
        rv_quizList.setLayoutManager(new LinearLayoutManager(this));
        rv_quizList.setAdapter(adapter);


        if (accessLevel.equals("Admin")) {
            if (listType.equals("all")) {
                tv_quizListHeading.setText(R.string.all_quizzes);
            }
        } else if (accessLevel.equals("Player")) {
            if (listType.equals("ongoing")) {
                tv_quizListHeading.setText(R.string.ongoing_quizzes);
            } else if (listType.equals("upcoming")) {
                tv_quizListHeading.setText(R.string.upcoming_quizzes);
            } else if (listType.equals("past")) {
                tv_quizListHeading.setText(R.string.past_quizzes);
            } else if (listType.equals("participated")) {
                tv_quizListHeading.setText(R.string.participated_quizzes);
            }
        }
    }

    private void loadQuizzes() {
        quizDAO.get().addListenerForSingleValueEvent(new ValueEventListener() {
            @Override
            public void onDataChange(@NonNull DataSnapshot snapshot) {
                ArrayList<Quiz> quizzes = new ArrayList<>();
                if (listType.equals("all")) {
                    for (DataSnapshot data : snapshot.getChildren()) {
                        Quiz quiz = data.getValue(Quiz.class);
                        quiz.setKey(data.getKey());
                        quizzes.add(quiz);
                    }
                } else if (listType.equals("ongoing")) {
                    for (DataSnapshot data : snapshot.getChildren()) {
                        Quiz quiz = data.getValue(Quiz.class);
                        try {
                            Date startDate = dateFormat.parse(quiz.getStartDate());
                            Date endDate = dateFormat.parse(quiz.getEndDate());
                            if ((currentDate.before(endDate) && currentDate.after(startDate))
                                    || currentDate.equals(endDate) ||
                                    currentDate.equals(startDate)) {
                                quiz.setKey(data.getKey());
                                quizzes.add(quiz);
                            }
                        } catch (ParseException e) {
                            e.printStackTrace();
                        }
                    }
                } else if (listType.equals("upcoming")) {
                    for (DataSnapshot data : snapshot.getChildren()) {
                        Quiz quiz = data.getValue(Quiz.class);
                        try {
                            Date startDate = dateFormat.parse(quiz.getStartDate());
                            if (currentDate.before(startDate)) {
                                quiz.setKey(data.getKey());
                                quizzes.add(quiz);
                            }
                        } catch (ParseException e) {
                            e.printStackTrace();
                        }
                    }

                } else if (listType.equals("past")) {
                    for (DataSnapshot data : snapshot.getChildren()) {
                        Quiz quiz = data.getValue(Quiz.class);
                        try {
                            Date endDate = dateFormat.parse(quiz.getEndDate());
                            if (currentDate.after(endDate)) {
                                quiz.setKey(data.getKey());
                                quizzes.add(quiz);
                            }
                        } catch (ParseException e) {
                            e.printStackTrace();
                        }
                    }
                } else if (listType.equals("participated")) {
                    for (DataSnapshot data : snapshot.getChildren()) {
                        Quiz quiz = data.getValue(Quiz.class);
                        quiz.setKey(data.getKey());
                        quizzes.add(quiz);
                    }
                }
                int i = 0;
                while (i < quizzes.size()) {
                    try {
                        int quizScore = participatedQuizzes.get(quizzes.get(i).getKey());
                        quizzes.get(i).setScore("" + quizScore);
                        i++;
                    } catch (NullPointerException e) {
                        e.printStackTrace();
                        if (listType.equals("participated")){
                            quizzes.remove(quizzes.get(i));
                        }
                        else {
                            i++;
                        }
                    }
                }
                adapter.setItems(quizzes);
                adapter.notifyDataSetChanged();


            }

            @Override
            public void onCancelled(@NonNull DatabaseError error) {

            }
        });
    }

    private void loadUserParticipatedQuizzes() {
        UserDAO userDAO = new UserDAO();
        userDAO.get(userID).addListenerForSingleValueEvent(new ValueEventListener() {
            @Override
            public void onDataChange(@NonNull DataSnapshot snapshot) {
                user = snapshot.getValue(User.class);
                participatedQuizzes = user.getParticipatedQuizzes();
//                try {
//                    participatedQuizzes = new String[user.getParticipatedQuizzes().size()][2];
//
//                }
//                catch (NullPointerException e){
//                    e.printStackTrace();
//                    participatedQuizzes = new String[0][2];
//                }
//                if (user!=null) {
//                    participatedQuizzes = user.getParticipatedQuizzes();
//                }
            }

            @Override
            public void onCancelled(@NonNull DatabaseError error) {

            }
        });

    }
}

