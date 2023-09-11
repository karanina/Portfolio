package io.github.karanina.exercises;

import androidx.appcompat.app.AppCompatActivity;
import androidx.appcompat.widget.SearchView;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import android.content.Context;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.ImageView;
import android.widget.TextView;
import android.widget.Toast;

import java.util.ArrayList;
import java.util.List;

import io.github.karanina.exercises.model.Drink;
import io.github.karanina.exercises.model.Drinks;
import io.github.karanina.exercises.model.Favourite;
import io.github.karanina.exercises.rest.CocktailControllerRESTAPI;
import io.github.karanina.exercises.rest.CocktailsRESTAPI;
import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

public class AllCocktails extends AppCompatActivity implements View.OnClickListener{

    RecyclerView rv_allCocktails;
    ImageView btn_goBack;
    SearchView searchAllCocktails;
    AllCocktailsRVAdapter adapter;
//    Drinks drinks;
//    ArrayList<Drink> drinkList;
    CocktailControllerRESTAPI cocktailControllerRESTAPI;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_all_cocktails);


        // Gain access to the Recycler View in the activity_all_cocktails.xml file.
        rv_allCocktails = findViewById(R.id.rv_allCocktails);

        rv_allCocktails.setLayoutManager(new LinearLayoutManager(this));
        adapter = new AllCocktailsRVAdapter(this);
        rv_allCocktails.setAdapter(adapter);

        btn_goBack = findViewById(R.id.btn_goBack);
        btn_goBack.setOnClickListener(this);

        searchAllCocktails = findViewById(R.id.searchAllCocktails);
        searchAllCocktails.clearFocus();

        cocktailControllerRESTAPI = new CocktailControllerRESTAPI();
        cocktailControllerRESTAPI.start(getApplicationContext(), rv_allCocktails);


        searchAllCocktails.setOnQueryTextListener(new SearchView.OnQueryTextListener() {
            @Override
            public boolean onQueryTextSubmit(String query) {
                return false;
            }

            @Override
            public boolean onQueryTextChange(String newText) {
                if (newText != null) {
                    cocktailControllerRESTAPI = new CocktailControllerRESTAPI();
                    cocktailControllerRESTAPI.start(getApplicationContext(), rv_allCocktails, newText);
                    return true;
                }

                return false;
            }
        });

    }


    @Override
    public void onClick(View view) {
        if (view.getId() == btn_goBack.getId()){
            finish();
        }

    }
}