package io.github.karanina.exercises;

import com.google.android.gms.tasks.Task;
import com.google.firebase.database.DatabaseReference;
import com.google.firebase.database.FirebaseDatabase;
import com.google.firebase.database.Query;

import java.util.HashMap;

import io.github.karanina.exercises.model.Ingredient;

public class IngredientDAO {

    private DatabaseReference databaseReference;

    public IngredientDAO() {
        FirebaseDatabase firebaseDatabase = FirebaseDatabase
                .getInstance("https://assignment2exercises-default-rtdb.firebaseio.com/");
        databaseReference = firebaseDatabase.getReference("Ingredient");
    }
    public Task<Void> add(Ingredient ingredient){

           return databaseReference.push().setValue(ingredient);

    }

    // takes in the primary key, and a key-value pair (hashMap) of the key and
    // the ingredient object.
    public Task<Void> update(String key, HashMap<String, Object> hashMap){
        return databaseReference.child(key).updateChildren(hashMap);
    }

    public Task<Void> delete(String key){
        return databaseReference.child(key).removeValue();
    }

    // Retrieves data from database
    public Query get(){
        return databaseReference.orderByKey();
    }

    public Query get(String key){return databaseReference.child(key);}


}
