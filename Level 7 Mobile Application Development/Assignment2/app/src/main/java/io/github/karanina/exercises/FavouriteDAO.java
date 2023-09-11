package io.github.karanina.exercises;

import com.google.android.gms.tasks.Task;
import com.google.firebase.database.DatabaseReference;
import com.google.firebase.database.FirebaseDatabase;
import com.google.firebase.database.Query;

import io.github.karanina.exercises.model.Drink;
import io.github.karanina.exercises.model.Favourite;

public class FavouriteDAO {
    private DatabaseReference databaseReference;

    public FavouriteDAO() {
        FirebaseDatabase firebaseDatabase = FirebaseDatabase
                .getInstance("https://assignment2exercises-default-rtdb.firebaseio.com/");
        databaseReference = firebaseDatabase.getReference("Favourite");
    }
    public Task<Void> add(Drink drink){
        return databaseReference.push().setValue(drink);
    }


    public Task<Void> remove(String key){
        return databaseReference.child(key).removeValue();
    }

    // Retrieves data from database
    public Query get(){
        return databaseReference.orderByKey();
    }
    // Retrieves data from database
    public Query get(String key){
        return databaseReference.child(key);
    }


}
