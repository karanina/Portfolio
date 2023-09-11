package io.github.karanina.triviaquiz;

import com.google.android.gms.tasks.Task;
import com.google.firebase.database.DatabaseReference;
import com.google.firebase.database.FirebaseDatabase;
import com.google.firebase.database.Query;

import java.util.HashMap;

import io.github.karanina.triviaquiz.model.Quiz;
import io.github.karanina.triviaquiz.model.User;

public class QuizDAO {
    FirebaseDatabase firebaseDatabase;
    DatabaseReference databaseReference;

    public QuizDAO() {
        firebaseDatabase = FirebaseDatabase.
                getInstance("https://assignment2triviaquiz-default-rtdb.firebaseio.com/");
        databaseReference = firebaseDatabase.getReference("Quiz");
    }

    public Task<Void> add(Quiz quiz){

        return databaseReference.push().setValue(quiz);

    }

    public Query get(){
        return databaseReference.orderByKey();
    }

    public Query getQuiz(String quizKey){
        return databaseReference.child(quizKey);
    }

    public Task<Void> update(String key, HashMap<String, Object> hashMap){
        return databaseReference.child(key).updateChildren(hashMap);
    }

    public Task<Void> delete(String quizKey) {
        return databaseReference.child(quizKey).removeValue();
    }
}
