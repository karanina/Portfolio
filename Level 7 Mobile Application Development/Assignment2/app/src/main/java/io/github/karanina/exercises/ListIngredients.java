package io.github.karanina.exercises;

import androidx.annotation.NonNull;
import androidx.appcompat.app.AppCompatActivity;
import androidx.appcompat.widget.SearchView;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import android.os.Bundle;
import android.view.Menu;
import android.view.MenuItem;
import android.widget.ImageView;
import android.widget.Toast;

import com.google.firebase.database.DataSnapshot;
import com.google.firebase.database.DatabaseError;
import com.google.firebase.database.DatabaseReference;
import com.google.firebase.database.FirebaseDatabase;
import com.google.firebase.database.ValueEventListener;

import java.util.ArrayList;

import io.github.karanina.exercises.model.Ingredient;

public class ListIngredients extends AppCompatActivity {

    RecyclerView rv_listIngredients;
    ListIngredientsRVAdapter adapter;
    IngredientDAO ingredientDAO;
    ImageView btn_goBack;
    SearchView searchIngredients;
    ArrayList<Ingredient> ingredients = new ArrayList<>();;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_list_ingredients);

        // Gain access to the Recycler View in the activity_list_ingredients.xml file.
        rv_listIngredients = findViewById(R.id.rv_listIngredients);

        btn_goBack = findViewById(R.id.btn_goBack);
        btn_goBack.setOnClickListener(view -> finish());

        searchIngredients = findViewById(R.id.searchIngredients);
        searchIngredients.clearFocus();

        loadData();

        // Create and set the recycler view adapter.
        adapter = new ListIngredientsRVAdapter(this, ingredients);
        rv_listIngredients.setLayoutManager(new LinearLayoutManager(this));
        rv_listIngredients.setAdapter(adapter);


        searchIngredients.setOnQueryTextListener(new SearchView.OnQueryTextListener() {
            @Override
            public boolean onQueryTextSubmit(String query) {
                return false;
            }

            @Override
            public boolean onQueryTextChange(String newText) {
                if (newText != null) {
                    search(newText);
                    return true;
                }

                return false;
            }
        });

    }

    private void loadData() {
        ingredientDAO = new IngredientDAO();
        ingredientDAO.get().addListenerForSingleValueEvent(new ValueEventListener() {
            @Override
            public void onDataChange(@NonNull DataSnapshot snapshot) {
                for (DataSnapshot data : snapshot.getChildren()) {
                    Ingredient ingredient = data.getValue(Ingredient.class);
                    ingredient.setKey(data.getKey());
                    ingredients.add(ingredient);
                }
                adapter.notifyDataSetChanged();
            }

            @Override
            public void onCancelled(@NonNull DatabaseError error) {

            }
        });
    }
    public void search (String searchQuery){
        ArrayList<Ingredient> filteredList = new ArrayList<>();
        for (Ingredient ingredient : ingredients){
            if (ingredient.getName().toLowerCase().contains(searchQuery.toLowerCase())){
                filteredList.add(ingredient);
            }
        }
        if (filteredList.isEmpty()){
            Toast.makeText(this,
                    "No ingredients containing " + searchQuery + " are in the database.",
                    Toast.LENGTH_SHORT).show();
        }
        else {
            adapter.setItems(filteredList);
        }
    }
}
