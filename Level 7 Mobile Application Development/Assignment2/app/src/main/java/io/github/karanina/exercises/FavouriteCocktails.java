package io.github.karanina.exercises;

import androidx.annotation.NonNull;
import androidx.appcompat.app.AppCompatActivity;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import android.os.Bundle;
import android.widget.ImageView;
import android.widget.Toast;

import androidx.appcompat.widget.SearchView;

import com.google.firebase.database.DataSnapshot;
import com.google.firebase.database.DatabaseError;
import com.google.firebase.database.ValueEventListener;

import java.util.ArrayList;


import io.github.karanina.exercises.model.Drink;
import io.github.karanina.exercises.model.Favourite;
import io.github.karanina.exercises.model.Ingredient;


public class FavouriteCocktails extends AppCompatActivity {

    RecyclerView rv_favouriteCocktails;
    FavouriteCocktailsRVAdapter adapter;
    FavouriteDAO favouriteDAO;
    ImageView btn_goBack;
    String key = null;
    SearchView searchFavourites;
    ArrayList<Favourite> favourites = new ArrayList<>();

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_favourite_cocktails);

        // Gain access to the Recycler View in the activity_favourite_cocktails.xml file.
        rv_favouriteCocktails = findViewById(R.id.rv_favouriteCocktails);

        btn_goBack = findViewById(R.id.btn_goBack);
        btn_goBack.setOnClickListener(view -> finish());

        searchFavourites = findViewById(R.id.searchFavourites);
        searchFavourites.clearFocus();

        // Create and set the recycler view adapter.
        adapter = new FavouriteCocktailsRVAdapter(this);
        rv_favouriteCocktails.setLayoutManager(new LinearLayoutManager(this));
        rv_favouriteCocktails.setAdapter(adapter);

        favouriteDAO = new FavouriteDAO();
        loadData();

        searchFavourites.setOnQueryTextListener(new SearchView.OnQueryTextListener() {
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
        favouriteDAO.get().addListenerForSingleValueEvent(new ValueEventListener() {
            @Override
            public void onDataChange(@NonNull DataSnapshot snapshot) {

                for (DataSnapshot data : snapshot.getChildren()){
                    Favourite favourite = data.getValue(Favourite.class);
                    favourite.setKey(data.getKey());
                    favourites.add(favourite);
                    key = data.getKey();
                }
                adapter.setItems(favourites);
                adapter.notifyDataSetChanged();
            }

            @Override
            public void onCancelled(@NonNull DatabaseError error) {

            }
        });
    }

    public void search (String searchQuery){
        ArrayList<Favourite> filteredList = new ArrayList<>();
        for (Favourite drink : favourites){
            if (drink.getStrDrink().toLowerCase().contains(searchQuery.toLowerCase())){
                filteredList.add(drink);
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