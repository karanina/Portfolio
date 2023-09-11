package io.github.karanina.triviaquiz;

import com.google.android.gms.tasks.Task;
import com.google.firebase.database.DatabaseReference;
import com.google.firebase.database.FirebaseDatabase;
import com.google.firebase.database.Query;

import java.util.HashMap;

import io.github.karanina.triviaquiz.model.User;

public class UserDAO {
    FirebaseDatabase firebaseDatabase;
    DatabaseReference databaseReference;

    public UserDAO() {
        firebaseDatabase = FirebaseDatabase.
                getInstance("https://assignment2triviaquiz-default-rtdb.firebaseio.com/");
        databaseReference = firebaseDatabase.getReference("User");
    }

    public Task<Void> add(User user){

        return databaseReference.push().setValue(user);

    }

    public Query get(){
        return databaseReference.orderByKey();
    }

    public Query get(String userID){
        return databaseReference.child(userID);

    }
    public Task updateParticipatedQuizzes(User user){
return databaseReference.child(user.getUserKey()).child("participatedQuizzes").setValue(user.getParticipatedQuizzes());
    }
}
